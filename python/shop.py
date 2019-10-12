from network import network
import sys

conn = network()

if sys.argv[1] == "add":
    shopName = sys.argv[2]
    description = sys.argv[3].replace("_"," ")
    floor = sys.argv[4]
    profile = sys.argv[5]
    adminId = sys.argv[6]
    categoryId = sys.argv[7]

    saved = -1

    try:

        conn.cursor.execute(
            "insert into shop (shop.shop_name,shop.description,shop.floor,shop.profile,shop.ref_admin,shop.ref_category) values('" + shopName + "','" + description + "','" + floor + "','" + profile + "','" + adminId + "','" + categoryId + "')")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)




elif sys.argv[1] == "get":
    conn.cursor.execute("select shop.shop_name,shop.shop_id from shop where shop_name!='unknownS' ")

    for raw in conn.cursor:
        print(raw[0] + " " + str(raw[1]))




elif sys.argv[1] == "getinf":
    shopId = sys.argv[2]

    conn.cursor.execute(
        "select shop_name,description,profile,ref_admin,floor,ref_category,shop_id from shop where shop_id='" + shopId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":
    shopName = sys.argv[2]
    description = sys.argv[3].replace("_"," ")
    floor = sys.argv[4]
    profile = sys.argv[5]
    adminId = sys.argv[6]
    categoryId = sys.argv[7]
    shopId = sys.argv[8]

    saved = -1

    try:

        conn.cursor.execute(
            "update shop set shop_name= '" + shopName + "',description='" + description + "',profile='" + profile + "',floor='" + floor + "',ref_admin='" + adminId + "',ref_category='" + categoryId + "' where shop_id='" + shopId + "'")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)



elif sys.argv[1] == "delete":

    shopId = sys.argv[2]

    # user
    conn.cursor.execute("update user set user.ref_shop='2' where user.ref_shop='" + shopId + "'")

    # product
    conn.cursor.execute("update product set product.ref_shop='2' where product.ref_shop='" + shopId + "'")
    # shop

    conn.cursor.execute("delete from shop where shop_id='" + shopId + "'")

    print("0")

    conn.saveChangesTODB()

elif sys.argv[1]=="shop_user" and sys.argv[2]=="view":
    import pandas as pd
    import os


    def Convert(tup, di):
        for a, b in tup:
            di.setdefault(a, []).append(b)
        return di


    conn.cursor.execute("select shop_name, user from shop_user where shop_name!='unknownS'")
    listShopUser = list(conn.cursor.fetchall())

    conn.cursor.execute("select shop_nbuser.shop_name,shop_nbuser.nbuser from shop_nbuser where shop_name!='unknownS'")
    listShopNbUser = list(conn.cursor.fetchall())

    df1 = pd.DataFrame(listShopNbUser, columns=['shop_name', 'shop_nbuser'])
    df2 = pd.DataFrame(listShopUser, columns=['shop_name', 'user'])
    df = pd.concat([df1, df2], axis=1)
    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.Dispatch("Excel.Application")
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="shop_user" and sys.argv[2]=="plot":
    conn.cursor.execute("select shop_nbuser.shop_name,shop_nbuser.nbuser from shop_nbuser where shop_name!='unknownS'")
    listShopNbUser = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*listShopNbUser)
    indices = np.arange(len(listShopNbUser))
    plt.bar(indices, frequency, color='b')
    plt.xticks(indices, word, rotation='vertical')
    plt.xlabel("Shop")
    plt.ylabel("number of users")
    plt.tight_layout()
    from pylab import *

    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('Users in Shops')
    plt.show()

elif sys.argv[1]=="specificshop":
    userID=sys.argv[2]
    conn.cursor.execute("select * from shop_user where user_id='" + userID + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")


elif sys.argv[1]=="shop_supplier":
    shopId=sys.argv[3]
    conn.cursor.execute("select shop_name ,supplier_name from shop_supplier where shop_id='"+shopId+"'")
    a = list(conn.cursor.fetchall())
    import pandas as pd
    import networkx as nx
    import matplotlib.pyplot as plt

    df = pd.DataFrame(a, columns=['shop_name', 'supplier_name'])
    df.to_csv("temp.csv")
    if sys.argv[2]=="plot":
        # Build your graph
        G = nx.from_pandas_edgelist(df, 'shop_name', 'supplier_name', create_using=nx.DiGraph())
        # Plot it
        plt.figure(figsize=(13,6))
        nx.draw(G, pos=nx.spring_layout(G), with_labels=True,node_size=900 )
        plt.show()

elif sys.argv[1]=="shop_prices" and sys.argv[2]=="view":

    import pandas as pd
    import os


    def Convert(tup, di):
        for a, b in tup:
            di.setdefault(a, []).append(b)
        return di


    conn.cursor.execute(" select shop_name, prices from shop_prices where shop_name!='unknownS'")
    listShopPricesShop = list(conn.cursor.fetchall())

    df = pd.DataFrame(listShopPricesShop, columns=['shop_name', 'prices'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.Dispatch("Excel.Application")
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="shop_prices" and sys.argv[2]=="plot":
    conn.cursor.execute(" select shop_name, prices from shop_prices where shop_name!='unknownS'")
    listShopPricesShop = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*listShopPricesShop)
    indices = np.arange(len(listShopPricesShop))

    plt.pie(frequency, labels=word, startangle=90, autopct='%.1f%%')
    plt.tight_layout()
    from pylab import *

    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('Shops')
    plt.show()

elif sys.argv[1]=="shopSupplierProduct" :
    import pandas as pd
    import os
    shopID=sys.argv[2]



    conn.cursor.execute(" call shopsSuppliersProducts('"+shopID+"');")
    listshopSupplierProduct = list(conn.cursor.fetchall())

    df = pd.DataFrame(listshopSupplierProduct, columns=['shop', 'supplier', 'product'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.Dispatch("Excel.Application")
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="salaries_shop" :
    import pandas as pd
    import os
    shopID=sys.argv[2]
    userID=sys.argv[3]

    conn.cursor.execute("call ma_mall.salariesInShops('" + shopID + "', '" + userID + "');")
    listsalariesShops = list(conn.cursor.fetchall())
    if shopID == "0" and userID == "0":
        df = pd.DataFrame(listsalariesShops,
                          columns=['name', 'shop', 'fix salary', 'nbOfWorkYear', 'married', 'nb_children',
                                   'month salary'])
    else:
        df = pd.DataFrame(listsalariesShops,
                          columns=['name', 'fix salary', 'nbOfWorkYear', 'married', 'nb_children', 'month salary'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.Dispatch("Excel.Application")
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()
elif sys.argv[1] == "allShop":
    conn.cursor.execute( "select   shop_name, profile,  description  from shop where shop_name!='unknownS'")
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2]))

conn.closeDB()


