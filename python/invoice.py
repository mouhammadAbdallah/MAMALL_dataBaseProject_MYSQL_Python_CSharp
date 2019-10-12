from network import network
import sys

conn = network()

if sys.argv[1] == "add":

    customerID = sys.argv[2]
    orderDAte = sys.argv[3]
    requiredDAte = sys.argv[4]
    userId = sys.argv[5]
    time = sys.argv[6]
    invoiceContents = sys.argv[7]

    invoiceContents = invoiceContents.replace("_", " ")
    invoiceContents = invoiceContents.strip()
    if customerID != "0":
        conn.cursor.execute(
        "insert into invoice (invoice.ref_customer,invoice.order_date,invoice.requiered_date,invoice.ref_user,invoice.time)" +
        "values('" + customerID + "','" + orderDAte + "','" + requiredDAte + "','" + userId + "','" + time + "')")
    else:
        conn.cursor.execute(
            "insert into invoice (invoice.order_date,invoice.requiered_date,invoice.ref_user,invoice.time)" +
            "values('" + orderDAte + "','" + requiredDAte + "','" + userId + "','" + time + "')")
    conn.cursor.execute("select * from invoice")
    invoiceId = (list)((list(conn.cursor))[len(list(conn.cursor)) - 1])[0]

    invoiceItems = invoiceContents.split(" ")

    for i in range(0, len(invoiceItems), 2):
        productId = invoiceItems[i]
        qty = invoiceItems[i + 1]
        conn.cursor.execute(
            "insert into invoice_contents(invoice_contents.ref_invoice,invoice_contents.ref_product,invoice_contents.quantity)" +
            "values('" + str(invoiceId) + "','" + str(productId) + "','" + qty + "')")

    print("1")
    conn.saveChangesTODB()


elif sys.argv[1] == "get":
    userId=sys.argv[2]
    conn.cursor.execute("select invoice.invoice_id from invoice where ref_user in (select shop_user.user_id from shop_user where shop_user.user_id ='"+userId+"')")

    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[0]))



elif sys.argv[1] == "getinf":

    invoiceId = sys.argv[2]

    conn.cursor.execute(
        "select invoice.invoice_id,invoice.ref_customer,invoice.order_date,invoice.requiered_date from invoice where invoice.invoice_id='" + invoiceId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")
    conn.cursor.execute(
        "select invoice_contents.ref_product,invoice_contents.quantity from invoice_contents where invoice_contents.ref_invoice='" + invoiceId + "'")
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1]))


elif sys.argv[1] == "editinfo":

    customerID = sys.argv[2]
    orderDAte = sys.argv[3]
    requiredDAte = sys.argv[4]
    userId = sys.argv[5]
    time = sys.argv[6]
    invoiceContents = sys.argv[7]
    invoiceId = sys.argv[8]

    invoiceContents = invoiceContents.replace("_", " ")
    invoiceContents = invoiceContents.strip()
    if customerID=="0":
        conn.cursor.execute(
        "update invoice set invoice.order_date='" + orderDAte + "',invoice.requiered_date='" + requiredDAte + "' where invoice.invoice_id='" + invoiceId + "'")
    else:
        conn.cursor.execute(
            "update invoice set invoice.ref_customer='" + customerID + "',invoice.order_date='" + orderDAte + "',invoice.requiered_date='" + requiredDAte + "' where invoice.invoice_id='" + invoiceId + "'")

    conn.cursor.execute("delete from invoice_contents where invoice_contents.ref_invoice='" + invoiceId + "'")

    invoiceItems = invoiceContents.split(" ")

    for i in range(0, len(invoiceItems), 2):
        productId = invoiceItems[i]
        qty = invoiceItems[i + 1]
        conn.cursor.execute(
            "insert into invoice_contents(invoice_contents.ref_invoice,invoice_contents.ref_product,invoice_contents.quantity)" +
            "values('" + invoiceId + "','" + productId + "','" + qty + "')")

    print("1")
    conn.saveChangesTODB()


elif sys.argv[1] == "delete":

    invoiceId = sys.argv[2]

    conn.cursor.execute("delete from invoice_contents where invoice_contents.ref_invoice='" + invoiceId + "'")

    conn.cursor.execute("delete from invoice where invoice_id='" + invoiceId + "'")

    print("1")
    conn.saveChangesTODB()

elif sys.argv[1] == "ShowAllTheInvoicesOfTheShop":
    userId=sys.argv[2]
    conn.cursor.execute(
        "select  invoicedetails.invoice_id,order_date,time,product_name,quantity,unit_price,per_discount,final_price,ref_user,product_id from invoicedetails where invoicedetails.ref_user in (select shop_user.user_id from shop_user where shop_user.shop_id=(select shop_user.shop_id from shop_user where shop_user.user_id ='"+userId+"'))")

    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1]) + " " + str(raw[2]) + " " + str(raw[3]) + " " + str(raw[4]) + " " + str(
            raw[5]) + " " + str(raw[6]) + " " + str(raw[7]) + " " + str(raw[8])+ " " + str(raw[9]))
elif sys.argv[1]=="operation" and sys.argv[2]=="view":

    import pandas as pd
    import os

    userID=sys.argv[3]
    conn.cursor.execute(" call productOperations('"+userID+"');")
    listOpera = list(conn.cursor.fetchall())

    df = pd.DataFrame(listOpera, columns=['order_date',' hour', 'product_name', 'quantity', 'final_price', 'profit'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.gencache.EnsureDispatch('Excel.Application')
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="avgCustByHoursInAShop" and sys.argv[2]=="plot":
    userID=sys.argv[3]

    conn.cursor.execute(" call avgCustByHoursInAShop('" + userID + "');")
    CustByHours = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*CustByHours)

    plt.plot(word, frequency)
    plt.tight_layout()
    from pylab import *

    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('nb of customer by hour')
    plt.show()
elif sys.argv[1] == "avgCustByHoursInAShop" and sys.argv[2] == "view":
    userID = sys.argv[3]
    import pandas as pd
    import os
    conn.cursor.execute(" call avgCustByHoursInAShop('" + userID + "');")
    CustByHours = list(conn.cursor.fetchall())


    df = pd.DataFrame(CustByHours, columns=['hour', ' average of nb customer'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.gencache.EnsureDispatch('Excel.Application')
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()
elif sys.argv[1]=="customerInShopInWeek" and sys.argv[2]=="plot":
    userID=sys.argv[3]

    conn.cursor.execute(" call customerInShopInWeek('" + userID + "');")
    CustByWeek = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*CustByWeek)

    plt.plot(word, frequency)
    plt.tight_layout()
    from pylab import *

    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('nb of customer by week')
    plt.show()
elif sys.argv[1] == "customerInShopInWeek" and sys.argv[2] == "view":
    userID = sys.argv[3]
    import pandas as pd
    import os
    conn.cursor.execute(" call customerInShopInWeek('" + userID + "');")
    CustByWeek = list(conn.cursor.fetchall())


    df = pd.DataFrame(CustByWeek, columns=['day', ' average of nb customer'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.gencache.EnsureDispatch('Excel.Application')
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

conn.closeDB()


