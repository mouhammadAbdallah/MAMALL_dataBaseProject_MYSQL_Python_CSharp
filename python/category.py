from network import network
import sys

conn = network()

if sys.argv[1] == "add":

    categoryName = sys.argv[2]
    description = sys.argv[3].replace("_"," ")
    profile = sys.argv[4]
    adminID = sys.argv[5]

    saved = -1

    try:
        conn.cursor.execute("call insertCategory('"+categoryName+"','"+description+"','"+profile+"','"+adminID+"');")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)




elif sys.argv[1] == "get":
    conn.cursor.execute("call getCategoryNamesWithId();")

    for raw in conn.cursor:
        print(raw[0] + " " + str(raw[1]))



elif sys.argv[1] == "getinf":

    categoryId = sys.argv[2]

    conn.cursor.execute(
        "call ma_mall.getCategoryInf('"+categoryId+"');")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":

    categoryName = sys.argv[2]
    description = sys.argv[3].replace("_"," ")
    profile = sys.argv[4]
    categoryId = sys.argv[5]

    saved = -1

    try:
        conn.cursor.execute("call updateCategory('"+categoryName+"','"+description+"','"+profile+"','"+categoryId+"');")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)


elif sys.argv[1] == "delete":

    categoryId = sys.argv[2]
    conn.cursor.execute("call deleteCategory('"+categoryId+"');")
    print("0")

    conn.saveChangesTODB()
elif sys.argv[1]=="category_shop" and sys.argv[2]=="view":
    import pandas as pd
    import os

    categoryId=sys.argv[3];
    conn.cursor.execute("call ma_mall.categoriesWithShops('"+categoryId+"');")
    listCategShop = list(conn.cursor.fetchall())

    conn.cursor.execute("call ma_mall.categoriesWithNbShops('"+categoryId+"');")
    listCategNbShop = list(conn.cursor.fetchall())

    df1 = pd.DataFrame(listCategNbShop, columns=['Category', 'Number OF Shops'])
    df2 = pd.DataFrame(listCategShop, columns=['Category Name', 'Shop Name'])
    df = pd.concat([df1, df2], axis=1)
    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.Dispatch("Excel.Application")
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()

elif sys.argv[1]=="category_shop" and sys.argv[2]=="plot":
    conn.cursor.execute("call ma_mall.categoriesWithNbShops('0');")
    listCategNbShop = list(conn.cursor.fetchall())

    import numpy as np
    import matplotlib.pyplot as plt

    plt.rc('figure', figsize=[10, 7])
    word = []
    frequency = []
    word, frequency = zip(*listCategNbShop)
    indices = np.arange(len(listCategNbShop))
    plt.bar(indices, frequency, color='r')
    plt.xticks(indices, word, rotation='vertical')
    plt.xlabel("category")
    plt.ylabel("number of shops")
    plt.tight_layout()
    from pylab import *
    thismanager = get_current_fig_manager()
    thismanager.window.wm_geometry("+240+40")
    plt.title('shops in Categories')
    plt.show()
elif sys.argv[1] == "allCategory":
    conn.cursor.execute("select   category_name, profile  from category where category_id !=10")
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1]))



conn.closeDB()


