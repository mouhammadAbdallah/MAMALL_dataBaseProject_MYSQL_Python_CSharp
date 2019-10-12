import plotly_express as px
import pandas as pd
from plotly.offline import plot
from network import network
import sys

conn=network()

if sys.argv[1]=="customerTimeDistributionInADayForTheMall":
    orderDAte=sys.argv[3]
    conn.cursor.execute("select * from customertimedistributionindays where order_date='" + orderDAte + "'")
    df = pd.DataFrame(list(conn.cursor), columns=['hour', 'date', 'nbOfCustomer'])
    print(df)
    df.to_csv("temp.csv")
    if sys.argv[2]=="plot":
        plot(px.scatter(df, x="hour", y="nbOfCustomer"))


elif sys.argv[1]=="customerTimeDistributionInWeekDaysForTheMall":
    conn.cursor.execute("select * from customertimedistributioninweekdays ")
    df = pd.DataFrame(list(conn.cursor), columns=['hour', 'day', 'nbOfCustomer'])
    print(df)
    df.to_csv("temp.csv")
    if sys.argv[2] == "plot":
        plot(px.scatter(df, x="hour", y="nbOfCustomer", color='day', size='nbOfCustomer'))




conn.closeDB()
