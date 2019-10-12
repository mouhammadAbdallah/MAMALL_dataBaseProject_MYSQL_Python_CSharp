from network import network
import sys

conn = network()

if sys.argv[1] == "add":
    productName = sys.argv[2]
    pPrice = sys.argv[3]
    uPrice = sys.argv[4]
    qtyPerUnit = sys.argv[5]
    description = sys.argv[6]
    supplierID = sys.argv[7]
    userId = sys.argv[8]
    profile = sys.argv[9]

    saved = -1

    try:

        conn.cursor.execute("select user.ref_shop from user where user_id='" + userId + "'")

        shopID = (list((list(conn.cursor))[0]))[0];

        conn.cursor.execute(
            "insert into product (product.ref_shop,product.product_name,product.purchase_price,product.unit_price," +
            "product.picture,product.ref_supplier,product.quantity_per_unit,product.description)" +
            "values('" + str(
                shopID) + "','" + productName + "','" + pPrice + "','" + uPrice + "','" + profile + "','" + supplierID + "','" + qtyPerUnit + "','" + description + "')"
        )

        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1] == "getdetails":
    userId=sys.argv[2]
    conn.cursor.execute(    "select product_details.product_name,product_details.product_id,product_details.description,product_details.unit_price,product_details.picture,COALESCE(product_details.rate_percentage, 0) as rate_percentage,product_details.discountType from product_details where product_details.ref_shop=(select shop_user.shop_id from shop_user where shop_user.user_id ='"+userId+"') ")


    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2])+ " " + str(raw[3])+ " " + str(raw[4])+ " " + str(raw[5])+ " " + str(raw[6]))


elif sys.argv[1] == "get":
    userId=sys.argv[2]
    conn.cursor.execute("select product_details.product_name,product_details.product_id from product_details where product_details.ref_shop=(select shop_user.shop_id from shop_user where shop_user.user_id ='"+userId+"') ")


    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1]))



elif sys.argv[1] == "getinf":
    productId = sys.argv[2]

    conn.cursor.execute("select * from product where product_id='" + productId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")




elif sys.argv[1] == "editinfo":

    productName = sys.argv[2]
    pPrice = sys.argv[3]
    uPrice = sys.argv[4]
    qtyPerUnit = sys.argv[5]
    description = sys.argv[6]
    supplierID = sys.argv[7]
    userId = sys.argv[8]
    profile = sys.argv[9]
    productId = sys.argv[10]

    saved = -1

    try:

        conn.cursor.execute(
            "update product set product.product_name='" + productName + "',product.purchase_price='" + pPrice + "',product.unit_price='" + uPrice + "',product.picture='" + profile + "'," +
            "product.ref_supplier='" + supplierID + "',product.quantity_per_unit='" + qtyPerUnit + "',product.description='" + description + "' " +
            "where product.product_id='" + productId + "'"
        )

        saved = productId
        conn.saveChangesTODB()

    finally:
        print(saved)



elif sys.argv[1] == "delete":
    productId = sys.argv[2]

    # invoice_contents
    conn.cursor.execute(
        "update invoice_contents set invoice_contents.ref_product='2' where invoice_contents.ref_product='" + productId + "'")

    # groupofsameproduct
    conn.cursor.execute(
        "update group_of_same_product set group_of_same_product.ref_product='2' where group_of_same_product.ref_product='" + productId + "'")

    # offer
    conn.cursor.execute("delete from offer where offer.ref_product='" + productId + "'")
    # product
    conn.cursor.execute("delete from product where product.product_id='" + productId + "'")

    print("0")

    conn.saveChangesTODB()

elif sys.argv[1]=="product_groups":
    shopId = sys.argv[3]
    conn.cursor.execute("select product_name, group_id  from shop_supplier where shop_id='"+shopId+"'")
    a = list(conn.cursor.fetchall())
    import pandas as pd
    import networkx as nx
    import matplotlib.pyplot as plt

    df = pd.DataFrame(a, columns=['product_name', 'group_id'])
    df.to_csv("temp.csv")
    if sys.argv[2]=="plot":
        # Build your graph
        G = nx.from_pandas_edgelist(df, 'product_name', 'group_id', create_using=nx.DiGraph())
        # Plot it
        plt.figure(figsize=(13, 6))
        nx.draw(G, pos=nx.spring_layout(G), with_labels=True, node_size=900)
        plt.show()
elif sys.argv[1]=="product_prices" and sys.argv[2]=="view":

    import pandas as pd
    import os


    def Convert(tup, di):
        for a, b in tup:
            di.setdefault(a, []).append(b)
        return di

    userID=sys.argv[3]
    conn.cursor.execute(" call productsWithPricesInAShop('"+userID+"');")
    listProductPricesShop = list(conn.cursor.fetchall())

    df = pd.DataFrame(listProductPricesShop, columns=['Product Name', 'Sales'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.gencache.EnsureDispatch('Excel.Application')
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="product_prices" and sys.argv[2]=="plot":
    userID=sys.argv[3]

    conn.cursor.execute(" call productsWithPricesInAShopSD('"+userID+"');")
    listProductPricesShop = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*listProductPricesShop)
    indices = np.arange(len(listProductPricesShop))

    plt.pie(frequency, labels=word, startangle=90, autopct='%.1f%%')
    plt.tight_layout()
    from pylab import *

    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('Products')
    plt.show()

elif sys.argv[1] == "ProductInStock":
    userId=sys.argv[2]
    conn.cursor.execute("call ma_mall.ProductInStock('"+userId+"');")


    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2]))
elif sys.argv[1] == "productinthemall":
    userId=sys.argv[2]
    conn.cursor.execute(    "select product_details.product_name,product_details.product_id,product_details.description,product_details.unit_price,product_details.picture,COALESCE(product_details.rate_percentage, 0) as rate_percentage,product_details.discountType from product_details where product_details.product_name!='unknownP' ")
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2])+ " " + str(raw[3])+ " " + str(raw[4])+ " " + str(raw[5])+ " " + str(raw[6]))


conn.closeDB()


