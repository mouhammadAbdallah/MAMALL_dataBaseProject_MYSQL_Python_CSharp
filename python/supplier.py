from network import network
import sys

conn = network()

if sys.argv[1] == "add":
    supplierName = sys.argv[2]
    fax = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]
    profile = sys.argv[6]
    webPage = sys.argv[7]
    street = sys.argv[8]
    building = sys.argv[9]
    floor = sys.argv[10]
    doorId = sys.argv[11]
    postalCode = sys.argv[12]
    phoneNumber = sys.argv[13]

    saved = -2

    try:

        try:
            conn.cursor.execute("Insert into address(country,city) values('" + country + "','" + city + "')")
        except:
            {}

        conn.cursor.execute("select * from address")
        addressId = [item[0] for item in conn.cursor
                     if item[1] == country and item[2] == city][0]

        conn.cursor.execute(
            "insert into full_address(full_address.street,full_address.building,full_address.floor,full_address.door_id," +
            "full_address.postal_code,full_address.phone_number) " +
            "values('" + street + "','" + building + "','" + floor + "','" + doorId + "','" + postalCode + "','" + phoneNumber + "')"
        )

        conn.cursor.execute("select * from full_address")
        fullAddressId = [item[0] for item in conn.cursor
                         if item[6] == phoneNumber][0]
        saved = -3

        conn.cursor.execute("insert into supplier(supplier.ref_address,supplier.profile,supplier.web_page," +
                       "supplier.ref_full_address,supplier.fax,supplier.supplier_name)" +
                       "values ('" + str(addressId) + "','" + profile + "','" + webPage + "','" + str(
            fullAddressId) + "','" + fax + "','" + supplierName + "')"
                       )
        conn.cursor.execute("SELECT * FROM ma_mall.supplier")
        supplierID = [item[0] for item in conn.cursor
                      if item[1] == supplierName][0]

        saved = supplierID
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1] == "get":
    conn.cursor.execute("select supplier.supplier_name,supplier.supplier_id " +
                   "from supplier where supplier.supplier_name!='unknownS'")

    for raw in conn.cursor:
        print(raw[0] + " " + str(raw[1]))




elif sys.argv[1] == "getinf":
    supplierId = sys.argv[2]

    conn.cursor.execute("select * from supplierinfo where supplier_id='" + supplierId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":

    supplierName = sys.argv[2]
    fax = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]
    profile = sys.argv[6]
    webPage = sys.argv[7]
    street = sys.argv[8]
    building = sys.argv[9]
    floor = sys.argv[10]
    doorId = sys.argv[11]
    postalCode = sys.argv[12]
    phoneNumber = sys.argv[13]
    supplierID = sys.argv[14]
    fullAddressId = sys.argv[15]

    saved = -2

    try:

        try:
            conn.cursor.execute("Insert into address(country,city) values('" + country + "','" + city + "')")
        except:
            {}

        conn.cursor.execute("select * from address")
        addressId = [item[0] for item in conn.cursor
                     if item[1] == country and item[2] == city][0]

        conn.cursor.execute(
            "update full_address set full_address.street='" + street + "',full_address.building='" + building + "',full_address.floor='" + floor + "',full_address.door_id='" + doorId + "'," +
            "full_address.postal_code='" + postalCode + "',full_address.phone_number='" + phoneNumber + "' where full_adress_id='" + fullAddressId + "' "
        )

        saved = -3
        conn.cursor.execute(
            "update supplier set supplier.ref_address='" + str(
                addressId) + "',supplier.fax='" + fax + "',supplier.profile='" + profile + "',supplier.supplier_name='" + supplierName + "'," +
            "supplier.web_page='" + webPage + "',supplier.ref_full_address='" + fullAddressId + "' where supplier.supplier_id='" + supplierID + "'")

        saved = supplierID
        conn.saveChangesTODB()

    finally:
        print(saved)



elif sys.argv[1] == "delete":

    supplierID = sys.argv[2]
    fullAddressId = sys.argv[3]

    # product
    conn.cursor.execute("update product set product.ref_supplier='2' where product.ref_supplier='" + supplierID + "'")

    # full_adress
    conn.cursor.execute("delete from full_address where full_address.full_adress_id='" + fullAddressId + "'")

    # supplier
    conn.cursor.execute("delete from supplier where supplier.supplier_id='" + supplierID + "'")

    print("0")

    conn.saveChangesTODB()

elif sys.argv[1]=="supplier_products":
    shopId=sys.argv[3]
    conn.cursor.execute("select supplier_name ,product_name from shop_supplier where shop_id='"+shopId+"'")
    a = list(conn.cursor.fetchall())
    import pandas as pd
    import networkx as nx
    import matplotlib.pyplot as plt

    df = pd.DataFrame(a, columns=['supplier_name', 'product_name'])
    df.to_csv("temp.csv")
    if sys.argv[2]=="plot":
        # Build your graph
        G = nx.from_pandas_edgelist(df, 'supplier_name', 'product_name', create_using=nx.DiGraph())
        # Plot it
        plt.figure(figsize=(13,6))
        nx.draw(G, pos=nx.spring_layout(G), with_labels=True,node_size=900 )
        plt.show()

elif sys.argv[1] == "AllSupplier":
    conn.cursor.execute("select  supplier_name, profile, web_page from supplier where supplier_name!='unknownS'")


    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2]))

conn.closeDB()


