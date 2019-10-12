from network import network
import sys

conn = network()

if sys.argv[1] == "add":

    firstname = sys.argv[2]
    lastname = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]

    saved = -1

    try:

        try:
            conn.cursor.execute("Insert into address(country,city) values('" + country + "','" + city + "')")
        except:
            {}

        conn.cursor.execute("select * from address")
        addressId = [item[0] for item in conn.cursor
                     if item[1] == country and item[2] == city][0]

        try:
            conn.cursor.execute(
                "Insert into person(first_name,last_name,ref_address) values('" + firstname + "','" + lastname + "','" + str(
                    addressId) + "')")
        except:
            {}

        conn.cursor.execute("select * from person")
        personId = [item[0] for item in conn.cursor
                    if item[1] == firstname and item[2] == lastname][0]

        conn.cursor.execute(
            "insert into customer (customer.ref_person) values('" + str(personId) + "')"
        )

        saved = personId
        conn.saveChangesTODB()

    finally:
        print(saved)




elif sys.argv[1] == "get":

    conn.cursor.execute("select person.first_name,person.last_name,customer.customer_id " +
                   "from person inner join customer " +
                   "on person.person_id=customer.ref_person where first_name!='unknownF'")

    for raw in conn.cursor:
        print(raw[0] + " " + raw[1] + " " + str(raw[2]))



elif sys.argv[1] == "getinf":

    customerId = sys.argv[2]

    conn.cursor.execute("select * from customerinfo where customer_id='" + customerId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":

    firstname = sys.argv[2]
    lastname = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]
    personId = sys.argv[6]

    saved = -1

    try:

        try:
            conn.cursor.execute("Insert into address(country,city) values('" + country + "','" + city + "')")
        except:
            {}

        conn.cursor.execute("select * from address")
        addressId = [item[0] for item in conn.cursor
                     if item[1] == country and item[2] == city][0]

        conn.cursor.execute(
            "update person set first_name= '" + firstname + "',last_name='" + lastname + "',ref_address='" + str(
                addressId) + "' where person_id='" + personId + "'")
        saved = 1
        conn.saveChangesTODB()

    finally:
        print(saved)



elif sys.argv[1] == "delete":
    personId = sys.argv[2]

    # online customer
    conn.cursor.execute("update online_customer set online_customer.ref_customer='4' where online_customer.ref_customer=(" +
                   "select customer.customer_id from customer where customer.ref_person='" + personId + "')")

    # invoice
    conn.cursor.execute("update invoice set invoice.ref_customer='4' where invoice.ref_customer=(" +
                   "select customer.customer_id from customer where customer.ref_person='" + personId + "')")

    # customer
    conn.cursor.execute("delete from customer where customer.ref_person='" + personId + "'")

    print("0")

    conn.saveChangesTODB()



conn.closeDB()


