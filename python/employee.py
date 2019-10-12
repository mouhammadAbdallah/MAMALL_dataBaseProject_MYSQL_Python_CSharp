from network import network
import sys

conn = network()

if sys.argv[1] == "add":

    firstname = sys.argv[2]
    lastname = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]
    birthdate = sys.argv[6]
    profile = sys.argv[7]
    username = sys.argv[8]
    password = sys.argv[9]
    street = sys.argv[10]
    building = sys.argv[11]
    floor = sys.argv[12]
    doorId = sys.argv[13]
    postalCode = sys.argv[14]
    phoneNumber = sys.argv[15]
    hireDate = sys.argv[16]
    fixSalary = sys.argv[17]
    married = sys.argv[18]
    nbChildren = sys.argv[19]
    email = sys.argv[20]

    saved = -1

    try:

        try:
            conn.cursor.execute("Insert into address(country,city) values('" + country + "','" + city + "')")
        except:{}


        conn.cursor.execute("select * from address")
        addressId = [item[0] for item in conn.cursor
                     if item[1] == country and item[2] == city][0]
        try:
            conn.cursor.execute(
            "Insert into person(first_name,last_name,ref_address) values('" + firstname + "','" + lastname + "','" + str(
                addressId) + "')")
        except:{}
        conn.cursor.execute("select * from person")
        personId = [item[0] for item in conn.cursor
                    if item[1] == firstname and item[2] == lastname][0]
        saved = -2

        conn.cursor.execute(
            "insert into full_address(full_address.street,full_address.building,full_address.floor,full_address.door_id," +
            "full_address.postal_code,full_address.phone_number) " +
            "values('" + street + "','" + building + "','" + floor + "','" + doorId + "','" + postalCode + "','" + phoneNumber + "')"
        )

        conn.cursor.execute("select * from full_address")
        fullAddressId = [item[0] for item in conn.cursor
                         if item[6] == phoneNumber][0]
        saved = -3

        conn.cursor.execute(
            "insert into employee(employee.ref_person,employee.birth_date,employee.profile,employee.user_name," +
            "employee.password,employee.ref_full_address,employee.hire_date,employee.fix_salary,employee.married," +
            "employee.nb_children,employee.email)" +
            "values ('" + str(
                personId) + "','" + birthdate + "','" + profile + "','" + username + "','" + password + "','" + str(
                fullAddressId) + "','" + hireDate + "','" + fixSalary + "','" + married + "','" + nbChildren + "','" + email + "' )"
            )
        conn.cursor.execute("SELECT * FROM ma_mall.employee")
        employeeID = [item[0] for item in conn.cursor
                      if item[1] == personId][0]

        saved = employeeID
        conn.saveChangesTODB()

    finally:
        print(saved)




elif sys.argv[1] == "get":

    conn.cursor.execute("select person.first_name,person.last_name,employee.employee_id " +
                   "from person inner join employee " +
                   "on person.person_id=employee.ref_person")

    for raw in conn.cursor:
        print(raw[0] + " " + raw[1] + " " + str(raw[2]))



elif sys.argv[1] == "getinf":

    employeeId = sys.argv[2]


    conn.cursor.execute("select * from employeeinfo where employee_id='" + employeeId + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")



elif sys.argv[1] == "editinfo":

    firstname = sys.argv[2]
    lastname = sys.argv[3]
    country = sys.argv[4]
    city = sys.argv[5]
    birthdate = sys.argv[6]
    profile = sys.argv[7]
    username = sys.argv[8]
    password = sys.argv[9]
    street = sys.argv[10]
    building = sys.argv[11]
    floor = sys.argv[12]
    doorId = sys.argv[13]
    postalCode = sys.argv[14]
    phoneNumber = sys.argv[15]
    hireDate = sys.argv[16]
    fixSalary = sys.argv[17]
    married = sys.argv[18]
    nbChildren = sys.argv[19]
    email = sys.argv[20]
    personId = sys.argv[21]
    employeeID = sys.argv[22]
    fullAddressId = sys.argv[23]

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
        saved = -2

        conn.cursor.execute(
            "update full_address set full_address.street='" + street + "',full_address.building='" + building + "',full_address.floor='" + floor + "',full_address.door_id='" + doorId + "'," +
            "full_address.postal_code='" + postalCode + "',full_address.phone_number='" + phoneNumber + "' where full_adress_id='" + fullAddressId + "' "
        )

        saved = -3
        conn.cursor.execute(
            "update employee set employee.ref_person='" + personId + "',employee.birth_date='" + birthdate + "',employee.profile='" + profile + "',employee.user_name='" + username + "'," +
            "employee.password='" + password + "',employee.ref_full_address='" + fullAddressId + "',employee.hire_date='" + hireDate + "',employee.fix_salary='" + fixSalary + "',employee.married='" + married + "'," +
            "employee.nb_children='" + nbChildren + "',employee.email='" + email + "' where employee.employee_id='" + employeeID + "'")

        saved = employeeID
        conn.saveChangesTODB()

    finally:
        print(saved)



elif sys.argv[1] == "delete":
    personId = sys.argv[2]
    employeeID = sys.argv[3]
    fullAddressId = sys.argv[4]

    # user
    conn.cursor.execute("update invoice set invoice.ref_user='1' where invoice.ref_user=(" +
                   "select user.user_id from user where user.ref_employee='" + employeeID + "')")
    conn.cursor.execute("delete from user where user.ref_employee='" + employeeID + "'")

    # admin
    conn.cursor.execute(
        "update category set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
    conn.cursor.execute(
        "update user set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
    conn.cursor.execute("select admin_id from adminstrator where ref_employee='" + employeeID + "'")
    try:
        adID = (list(list(conn.cursor)[0]))[0]
    except:
        adID = 0
    conn.cursor.execute("update adminstrator set ref_admin_dad='3' where ref_admin_dad = '" + str(adID) + "'")
    conn.cursor.execute(
        "update shop set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
    conn.cursor.execute("delete from adminstrator where ref_employee='" + employeeID + "'")

    # ancien employee
    conn.cursor.execute("delete from ancien_employee where ancien_employee.ref_employee='" + employeeID + "'")

    # employee
    conn.cursor.execute("delete from employee where employee.employee_id='" + employeeID + "'")

    # person
    conn.cursor.execute("delete from person where person.person_id='" + personId + "'")

    # full_adress
    conn.cursor.execute("delete from full_address where full_address.full_adress_id='" + fullAddressId + "'")

    print("0")

    conn.saveChangesTODB()

elif sys.argv[1]=="inf":

    employeeId = int(sys.argv[2])


    conn.cursor.execute(
        "select shop.shop_id,employee.employee_id from "+
        "employee inner join user on employee.employee_id=user.ref_employee "+
        "left outer join shop on shop.shop_id=user.ref_shop "+
        "where employee_id='"+str(employeeId)+"'")
    try:
        shopId = list(conn.cursor)[0][0]
    except:
        shopId = 0
    print(shopId)  # shopId of a user if shopId!=0(shopId=0 => not a user)

    conn.cursor.execute("select adminstrator.admin_id,employee.employee_id from employee inner join adminstrator on employee.employee_id=adminstrator.ref_employee where employee_id='"+str(employeeId)+"'")
    try:
        adminId = list(conn.cursor)[0][0]
    except:
        adminId = 0
    print(adminId)  # adminId of an adminstrator if adminId!=0(adminId=0 => not a admin)

    conn.cursor.execute("select stop_date from ancien_employee where ref_employee='" + str(employeeId) + "'")
    try:
        stopDate = list(conn.cursor)[0][0]
    except:
        stopDate = 0
    print(str(stopDate))  # stopDate of an employee if stopDate!=0(stopDate=0 => ancien employee)
    conn.cursor.execute("select employee.profile from employee where employee_id='"+str(employeeId)+"'")
    profile=list(conn.cursor.fetchall())[0][0]
    print(profile)

elif sys.argv[1]=="edit":

    employeeID = sys.argv[2]
    adminId = sys.argv[3]
    shopID = sys.argv[4]
    admin = sys.argv[5]
    stopDate = sys.argv[6]

    if shopID != "0":
        try:
            conn.cursor.execute(
                "insert into user (user.ref_employee,user.ref_admin,user.ref_shop) values('" + employeeID + "','" + adminId + "','" + shopID + "')")
        except:
            conn.cursor.execute(
                "update user set user.ref_shop='" + shopID + "' where user.ref_employee='" + employeeID + "'")

    else:
        conn.cursor.execute("update invoice set invoice.ref_user='1' where invoice.ref_user=(" +
                       "select user.user_id from user where user.ref_employee='" + employeeID + "')")
        conn.cursor.execute("delete from user where user.ref_employee='" + employeeID + "'")

    if admin != "0":
        try:
            conn.cursor.execute(
                "insert into adminstrator (adminstrator.ref_employee,adminstrator.ref_admin_dad) values('" + employeeID + "','" + adminId + "')")
        except:
            {}

    else:
        conn.cursor.execute(
            "update category set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
        conn.cursor.execute(
            "update user set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
        conn.cursor.execute("select admin_id from adminstrator where ref_employee='" + employeeID + "'")
        try:
            adID = (list(list(conn.cursor)[0]))[0]
        except:
            adID = 0;
        conn.cursor.execute("update adminstrator set ref_admin_dad='3' where ref_admin_dad = '" + str(adID) + "'")
        conn.cursor.execute(
            "update shop set ref_admin='3' where ref_admin=(select admin_id from adminstrator where ref_employee='" + employeeID + "')")
        conn.cursor.execute("delete from adminstrator where ref_employee='" + employeeID + "'")

    conn.cursor.execute("delete from ancien_employee where ancien_employee.ref_employee='" + employeeID + "'")
    if stopDate != "0":
        conn.cursor.execute(
            "insert into ancien_employee (ancien_employee.ref_employee,ancien_employee.stop_date) values('" + employeeID + "','" + stopDate + "')")

    print("0")

    conn.saveChangesTODB()


elif sys.argv[1]=="admin":
    adminID=sys.argv[2]
    conn.cursor.execute("select * from employeeinfo where admin_id='" + adminID + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")

elif sys.argv[1]=="user":
    userID=sys.argv[2]
    conn.cursor.execute("select * from employeeinfo where user_id='" + userID + "'")
    infos = list(list(conn.cursor)[0])
    print(*infos, sep="\n")

elif sys.argv[1]=="emplinf" and sys.argv[2]=="view":

    import pandas as pd
    import os


    userID=sys.argv[3]
    conn.cursor.execute("call ma_mall.employeeInfoForAShopOrAll('"+userID+"');")
    listemplinf = list(conn.cursor.fetchall())

    df = pd.DataFrame(listemplinf, columns=['name', 'country', 'city', 'birth_date',  'postal_code', 'phone_number', 'hire_date', 'fix_salary', 'email'])

    df.to_excel('temp.xlsx', index=None, header=True)
    import win32com.client as win32

    excel = win32.gencache.EnsureDispatch('Excel.Application')
    wb = excel.Workbooks.Open(os.getcwd() + r'\temp.xlsx')
    ws = wb.Worksheets("sheet1")
    ws.Columns.AutoFit()
    wb.Save()
    excel.Application.Quit()


elif sys.argv[1] == "allEmp":
    conn.cursor.execute( "select first_name, last_name,employeeinfo.profile, phone_number, email ,shop.shop_name from employeeinfo left outer join shop on shop.shop_id=ma_mall.shopIdOfUserId(user_id) where first_name!='unknownF' "  )
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2])+ " " + str(raw[3])+ " " + str(raw[4])+ " " + str(raw[5]))
elif sys.argv[1] == "endEmployee":
    conn.cursor.execute( "select first_name, last_name,employeeinfo.profile, phone_number, email ,stop_date from ancien_employee left outer join employeeinfo on employeeinfo.employee_id=ancien_employee.ref_employee" )
    for raw in conn.cursor:
        print(str(raw[0]) + " " + str(raw[1])+ " " + str(raw[2])+ " " + str(raw[3])+ " " + str(raw[4])+ " " + str(raw[5]))


conn.closeDB()


