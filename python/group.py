from network import network
import sys

conn = network()

if sys.argv[1] == "add":

    qty = sys.argv[2]
    productId = sys.argv[3]
    dateOfBuy = sys.argv[4]
    expirationDAte = sys.argv[5]

    saved = -1

    try:

        conn.cursor.execute(
            "insert into group_of_same_product (group_of_same_product.ref_product,group_of_same_product.quantity,group_of_same_product.date_of_buy," +
            "group_of_same_product.expiration_date) values('" + productId + "','" + qty + "','" + dateOfBuy + "','" + expirationDAte + "')")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1] == "get":
    userId=sys.argv[2]
    conn.cursor.execute(" select group_of_same_product.group_id,concat(group_of_same_product.group_id,'_',product_name) as groupName from group_of_same_product left outer join product on product.product_id=group_of_same_product.ref_product"
                            +" where product.ref_shop=ma_mall.shopIdOfUserId('"+userId+"')")

    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1]))



elif sys.argv[1] == "getinf":
    groupId = sys.argv[2]

    conn.cursor.execute("select * from group_of_same_product where group_of_same_product.group_id='" + groupId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":
    qty = sys.argv[2]
    productId = sys.argv[3]
    dateOfBuy = sys.argv[4]
    expirationDAte = sys.argv[5]
    groupId = sys.argv[6]

    saved = -1

    try:

        conn.cursor.execute(
            "update group_of_same_product set group_of_same_product.ref_product='" + productId + "',group_of_same_product.quantity='" + qty + "',group_of_same_product.date_of_buy='" + dateOfBuy + "'" +
            ",group_of_same_product.expiration_date='" + expirationDAte + "' where group_of_same_product.group_id='" + groupId + "'")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1] == "delete":
    groupId = sys.argv[2]

    conn.cursor.execute("delete from group_of_same_product where group_of_same_product.group_id='" + groupId + "'")

    print("0")
    conn.saveChangesTODB()

elif sys.argv[1] == "ShopGroup":
    userId=sys.argv[2]
    conn.cursor.execute("call ma_mall.ShopGroup('"+userId+"');")


    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2])+ " " + str(raw[3])+ " " + str(raw[4])+ " " + str(raw[5]))


conn.closeDB()


