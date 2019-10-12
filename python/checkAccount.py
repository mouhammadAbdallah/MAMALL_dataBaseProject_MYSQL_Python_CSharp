from network import network
import sys


employee=sys.argv[1]
username=sys.argv[2]
password=sys.argv[3]


conn = network()

conn.cursor.execute("SELECT * FROM "+employee+"accounts")

try:
    employeeId=[item[2] for item in conn.cursor
         if item[0] == username and item[1] == password][0]
except: employeeId =-1


conn.closeDB()
print(employeeId)

