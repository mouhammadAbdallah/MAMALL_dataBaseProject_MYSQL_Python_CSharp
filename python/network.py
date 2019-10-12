import pymysql


class network:
    def __init__(self):
        self.connection = pymysql.connect(host='MohamadAbdallah', port=3306, user='mohamad', passwd='MohamadAbdallah1998.com', db='ma_mall')
        self.cursor = self.connection.cursor()

    def saveChangesTODB(self):
        self.connection.commit()

    def closeDB(self):
        self.cursor.close()
        self.connection.close()