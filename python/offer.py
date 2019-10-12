from network import network
import sys

conn=network()

if sys.argv[1]=="add":

    productId = sys.argv[2]
    rate = sys.argv[3]
    desc = sys.argv[4]
    stratDAte = sys.argv[5]
    endDAte = sys.argv[6]

    saved = -1

    try:

        conn.cursor.execute(
            "insert into offer (offer.ref_product,offer.rate_percentage,offer.description,offer.start_date,offer.end_date) values('" + productId + "','" + rate + "','" + desc + "','" + stratDAte + "','" + endDAte + "')")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1]=="get":
    userId=sys.argv[2]
    conn.cursor.execute("select product.product_name,offer.offer_id from product inner join offer on product.product_id=offer.ref_product where ref_shop=ma_mall.shopIdOfUserId('"+userId+"')")

    for raw in conn.cursor:
        print(raw[0] + " " + str(raw[1]))

elif sys.argv[1]=="getinf":

    offerId = sys.argv[2]

    conn.cursor.execute("select * from offer where offer.offer_id='" + offerId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")

elif sys.argv[1]=="editinfo":
    productId = sys.argv[2]
    rate = sys.argv[3]
    desc = sys.argv[4]
    stratDAte = sys.argv[5]
    endDAte = sys.argv[6]
    offerID = sys.argv[7]

    saved = -1

    try:

        conn.cursor.execute(
            "update offer set offer.ref_product='" + productId + "',offer.rate_percentage='" + rate + "',offer.description='" + desc + "',offer.start_date='" + stratDAte + "',offer.end_date='" + endDAte + "' where offer.offer_id='" + offerID + "'")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)

elif sys.argv[1]=="delete":

    offerId = sys.argv[2]
    # offer
    conn.cursor.execute("delete from offer where offer.offer_id='" + offerId + "'")
    print("0")
    conn.saveChangesTODB()



conn.closeDB()


