-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: ma_mall
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `address` (
  `adress_id` int(11) NOT NULL AUTO_INCREMENT,
  `country` varchar(10) NOT NULL,
  `city` varchar(10) NOT NULL,
  PRIMARY KEY (`adress_id`),
  UNIQUE KEY `u_country_city` (`country`,`city`)
) ENGINE=InnoDB AUTO_INCREMENT=235 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (233,'africia','africia'),(234,'africia','africia\rn'),(109,'lebanon','akkar'),(7,'lebanon','batroun'),(4,'lebanon','beirut'),(1,'lebanon','dannyah'),(224,'lebanon','jbeil'),(212,'lebanon','kalamoun'),(199,'lebanon','mina'),(2,'lebanon','qubba'),(139,'lebanon','sour'),(5,'lebanon','tripoli'),(226,'lebanon','trpoli'),(211,'lenbanon','tripoli'),(232,'souria','dimashek'),(231,'sourya','dimashek'),(182,'unknownC','-'),(230,'yaban','changhai');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `adminaccounts`
--

DROP TABLE IF EXISTS `adminaccounts`;
/*!50001 DROP VIEW IF EXISTS `adminaccounts`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `adminaccounts` AS SELECT 
 1 AS `user_name`,
 1 AS `password`,
 1 AS `admin_id`,
 1 AS `employee_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `adminstrator`
--

DROP TABLE IF EXISTS `adminstrator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `adminstrator` (
  `admin_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_employee` int(11) NOT NULL,
  `ref_admin_dad` int(11) NOT NULL,
  PRIMARY KEY (`admin_id`),
  UNIQUE KEY `ref_employee_UNIQUE` (`ref_employee`),
  KEY `fk_ref_admin_dad_id` (`ref_admin_dad`),
  CONSTRAINT `fk_ref_admin_dad` FOREIGN KEY (`ref_admin_dad`) REFERENCES `adminstrator` (`admin_id`),
  CONSTRAINT `fk_ref_employee` FOREIGN KEY (`ref_employee`) REFERENCES `employee` (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adminstrator`
--

LOCK TABLES `adminstrator` WRITE;
/*!40000 ALTER TABLE `adminstrator` DISABLE KEYS */;
INSERT INTO `adminstrator` VALUES (3,1,3),(31,28,3),(34,37,3),(35,39,3),(37,44,31);
/*!40000 ALTER TABLE `adminstrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ancien_employee`
--

DROP TABLE IF EXISTS `ancien_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ancien_employee` (
  `ref_employee` int(11) NOT NULL,
  `stop_date` date NOT NULL,
  PRIMARY KEY (`ref_employee`),
  CONSTRAINT `fk_ref_employee1` FOREIGN KEY (`ref_employee`) REFERENCES `employee` (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ancien_employee`
--

LOCK TABLES `ancien_employee` WRITE;
/*!40000 ALTER TABLE `ancien_employee` DISABLE KEYS */;
INSERT INTO `ancien_employee` VALUES (2,'2019-05-23');
/*!40000 ALTER TABLE `ancien_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `category` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(20) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `profile` varchar(45) DEFAULT NULL,
  `ref_admin` int(11) NOT NULL,
  PRIMARY KEY (`category_id`),
  UNIQUE KEY `category_name_UNIQUE` (`category_name`),
  KEY `fk_ref_admin_idx` (`ref_admin`),
  KEY `fk_ref_admin5_idx` (`ref_admin`),
  CONSTRAINT `fk_ref_admin5` FOREIGN KEY (`ref_admin`) REFERENCES `adminstrator` (`admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'clothes','for all seasons','clothes',3),(10,'unknownC','-','category',3),(11,'food','fruits and meals','food',3),(12,'toys','toys for children','toys',31),(13,'drink','water and jus','drink',31),(14,'accessories','watches, glasses and others','accessories',31),(15,'cleaners','tissues, wipes and other cleaners','cleaners',31),(19,'birds','bird','birds',37);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `category_nbshop`
--

DROP TABLE IF EXISTS `category_nbshop`;
/*!50001 DROP VIEW IF EXISTS `category_nbshop`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `category_nbshop` AS SELECT 
 1 AS `category_name`,
 1 AS `nbshop`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `category_shop`
--

DROP TABLE IF EXISTS `category_shop`;
/*!50001 DROP VIEW IF EXISTS `category_shop`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `category_shop` AS SELECT 
 1 AS `category_name`,
 1 AS `shop_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customer` (
  `customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_person` int(11) NOT NULL,
  `ref_user` int(11) DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `u_ref_person` (`ref_person`),
  KEY `fk_ref_user1_idx` (`ref_user`),
  CONSTRAINT `fk_ref_person` FOREIGN KEY (`ref_person`) REFERENCES `person` (`person_id`),
  CONSTRAINT `fk_ref_user1` FOREIGN KEY (`ref_user`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (2,25,1),(3,26,17),(4,110,1),(6,123,16),(7,124,NULL),(8,125,NULL),(9,126,NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `customerinfo`
--

DROP TABLE IF EXISTS `customerinfo`;
/*!50001 DROP VIEW IF EXISTS `customerinfo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `customerinfo` AS SELECT 
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `country`,
 1 AS `city`,
 1 AS `person_id`,
 1 AS `customer_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `customertimedistributionindays`
--

DROP TABLE IF EXISTS `customertimedistributionindays`;
/*!50001 DROP VIEW IF EXISTS `customertimedistributionindays`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `customertimedistributionindays` AS SELECT 
 1 AS `hour`,
 1 AS `order_date`,
 1 AS `nbCustomer`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `customertimedistributioninweekdays`
--

DROP TABLE IF EXISTS `customertimedistributioninweekdays`;
/*!50001 DROP VIEW IF EXISTS `customertimedistributioninweekdays`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `customertimedistributioninweekdays` AS SELECT 
 1 AS `hour`,
 1 AS `day`,
 1 AS `nbCustomer`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `distributionofcustomerondatehour`
--

DROP TABLE IF EXISTS `distributionofcustomerondatehour`;
/*!50001 DROP VIEW IF EXISTS `distributionofcustomerondatehour`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `distributionofcustomerondatehour` AS SELECT 
 1 AS `shop_id`,
 1 AS `order_date`,
 1 AS `hour`,
 1 AS `nbOfCustomer`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_person` int(11) NOT NULL,
  `birth_date` date NOT NULL,
  `profile` varchar(45) DEFAULT NULL,
  `user_name` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `ref_full_address` int(11) NOT NULL,
  `hire_date` date NOT NULL,
  `fix_salary` double NOT NULL,
  `married` tinyint(1) NOT NULL,
  `nb_children` int(11) NOT NULL,
  `email` varchar(60) NOT NULL,
  PRIMARY KEY (`employee_id`),
  UNIQUE KEY `u_ref_person` (`ref_person`),
  UNIQUE KEY `u_account1` (`user_name`,`password`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `fk_ref_full_address_employee` (`ref_full_address`),
  CONSTRAINT `fk_ref_full_address_employee` FOREIGN KEY (`ref_full_address`) REFERENCES `full_address` (`full_adress_id`),
  CONSTRAINT `fk_ref_person_employee` FOREIGN KEY (`ref_person`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,22,'1998-03-10','mohamadabdallah','MohamadAbdallah','123456789',5,'2010-10-10',800,0,0,'mohamad1031998@gmail.com'),(2,23,'2000-04-16','mahmoudabdallah','MahmoudAbdallah','555555555',6,'2008-12-03',500,0,0,'mahmoudabdallah901a@gmail.com'),(28,79,'1998-05-17','raghadabdallah','RaghadAbdallah','979846494',52,'2019-05-17',500.5,0,0,'raghad1912207@gmail.com'),(37,108,'2019-05-21','employee','OmarAbdallah','3541861486146',62,'2019-05-21',100,1,2,'omarmb213@gmail.com'),(39,110,'1999-09-09','employee','unknownU','0000',64,'2000-02-02',0,0,0,'-'),(40,113,'1997-10-10','employee','AdnanWazzeh','46441644674',67,'2019-05-31',2000,1,0,'adnan656@gmail.com'),(41,114,'1978-06-01','fadwadaana','FadwaDaana','64sve6s84ss6e',68,'2019-06-09',1000,1,2,'foufou1928@outlook.com'),(42,117,'1991-06-09','alaaabdallah','AlaaAbdallah','56a4da684wd',69,'2019-06-09',450,0,0,'alaaAbd1990@hotmail.com'),(43,118,'1970-04-15','mahmouddaana','MahmoudDaana','684scs89v4s18',70,'2019-06-09',350,1,4,'mahmoudAbir12@gmail.com'),(44,119,'1980-03-29','baderdib','BaderNAjiha','6548aw6e6',71,'2019-06-09',600,1,2,'badour1980@ieee.com'),(45,120,'1985-02-26','rouaydadib','RouaydaDib','5848684dsf6',72,'2019-06-09',600,0,0,'rouada_DIb19@gmail.com'),(46,121,'1970-08-06','bachireldaya','ElDaya','654dsc84d84',73,'2019-06-09',2000,1,1,'daya1970@gmail.com'),(47,122,'1979-12-14','rayantout','RaYAnTout','84864818118',74,'2019-06-09',900,1,4,'rayan_Tout@gmail.com'),(48,127,'1989-07-25','employee','SamirMohsen','SamirMohsen',84,'2019-07-25',600,1,6,'samir@gmail.com');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `employeeinfo`
--

DROP TABLE IF EXISTS `employeeinfo`;
/*!50001 DROP VIEW IF EXISTS `employeeinfo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `employeeinfo` AS SELECT 
 1 AS `employee_id`,
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `country`,
 1 AS `city`,
 1 AS `birth_date`,
 1 AS `profile`,
 1 AS `user_name`,
 1 AS `password`,
 1 AS `street`,
 1 AS `building`,
 1 AS `floor`,
 1 AS `door_id`,
 1 AS `postal_code`,
 1 AS `phone_number`,
 1 AS `hire_date`,
 1 AS `fix_salary`,
 1 AS `married`,
 1 AS `nb_children`,
 1 AS `email`,
 1 AS `person_id`,
 1 AS `full_adress_id`,
 1 AS `user_id`,
 1 AS `admin_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `full_address`
--

DROP TABLE IF EXISTS `full_address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `full_address` (
  `full_adress_id` int(11) NOT NULL AUTO_INCREMENT,
  `street` varchar(20) NOT NULL,
  `building` varchar(10) NOT NULL,
  `floor` int(11) NOT NULL,
  `door_id` varchar(10) DEFAULT '1',
  `postal_code` varchar(20) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  PRIMARY KEY (`full_adress_id`),
  UNIQUE KEY `u_phone_number` (`phone_number`),
  UNIQUE KEY `u_full_adress` (`street`,`building`,`floor`,`door_id`,`postal_code`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `full_address`
--

LOCK TABLES `full_address` WRITE;
/*!40000 ALTER TABLE `full_address` DISABLE KEYS */;
INSERT INTO `full_address` VALUES (5,'ksara','abdallah',2,'1','240417','0096170581493'),(6,'ksara','abdallah',1,'1','240416','0096170434187'),(7,'sahla','zod',3,'1','240904','0096170175772'),(8,'mitan','dern',6,'3','958012','0096171015536'),(9,'dawra','addidas',1,'1','846516','0096149565189'),(52,'beraayel','ahdab',6,'12','8648944894','0096103965878'),(62,'mrahESlraj','abdallah',2,'1','31581461','0096171151821'),(64,'unknownS','-',0,'0','0','00000'),(66,'dawra','nike',2,'1','4245245','006916505961'),(67,'manar','badawi',7,'1','31543154','0096170306090'),(68,'daar','kabalan',2,'1','64afa485as','0096170244248'),(69,'sahla','abdallah',2,'1','sef486w4e','0096103256398'),(70,'ksara','nadai',1,'1','dfefe5ffe854e','0096103284989'),(71,'daar','najiha',1,'1','afeasreg516','0096170844965'),(72,'jamii','dib',3,'1','awfef254778','0096189069548'),(73,'mitan','badawi',9,'1','adewf684a1','0096103250298'),(74,'bahri','tout',1,'1','awfeaf864','0096170512876'),(75,'senElFil','lacoste',1,'1','1468d1d4v1','0096101259631'),(76,'chrelhelou','najar',1,'1','swac48s4','0096101159734'),(77,'dahia','samira',1,'1','684ed','0096107584691'),(78,'sheka','pepsi',1,'1','684812','0096108958761'),(79,'tebbaneh','1',1,'1','regre84','0096106249287'),(80,'qubba','1',1,'1','984sfe','0096106984367'),(81,'sou2','1',1,'1','6485wref','0096107896314'),(82,'abousamra','1',1,'1','864616wd','0096106957861'),(83,'105','1',1,'1','e85r4','00961098547315'),(84,'halab','allam',3,'1','545','00961705584793'),(85,'no','0',1,'1','684erf','00961967819850');
/*!40000 ALTER TABLE `full_address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group_of_same_product`
--

DROP TABLE IF EXISTS `group_of_same_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `group_of_same_product` (
  `group_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_product` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `date_of_buy` date NOT NULL,
  `expiration_date` date DEFAULT NULL,
  PRIMARY KEY (`group_id`),
  KEY `fk_ref_product_idx` (`ref_product`),
  CONSTRAINT `fk_ref_product` FOREIGN KEY (`ref_product`) REFERENCES `product` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group_of_same_product`
--

LOCK TABLES `group_of_same_product` WRITE;
/*!40000 ALTER TABLE `group_of_same_product` DISABLE KEYS */;
INSERT INTO `group_of_same_product` VALUES (1,1,30,'2019-05-08','2029-05-08'),(3,12,20,'2019-06-13','2029-07-05'),(4,11,30,'2019-06-13','2029-10-13'),(5,12,6,'2019-06-13','2029-05-17'),(6,13,10,'2019-06-17','2029-05-17'),(7,14,110,'2019-07-10','2029-05-17'),(8,15,100,'2019-07-10','2029-05-17'),(9,16,100,'2019-07-10','2029-05-17'),(10,17,103,'2019-07-10','2029-05-17'),(11,18,90,'2019-07-10','2029-05-17'),(12,19,100,'2019-07-10','2029-05-29'),(13,19,90,'2019-07-10','2029-05-17'),(14,21,19,'2019-07-10','2029-05-17'),(15,22,400,'2019-07-10','2029-05-17'),(16,23,50,'2019-07-12','2029-05-17'),(17,24,20,'2019-07-12','2029-05-17'),(18,25,10,'2019-07-12','2029-05-17'),(19,26,100,'2019-07-12','2029-05-17'),(20,27,50,'2019-07-12','2029-05-17'),(21,28,100,'2019-07-12','2029-05-17'),(22,29,20,'2019-07-12','2029-05-17'),(23,20,50,'2019-07-12','2029-05-17'),(24,24,90,'2019-07-12','2029-05-17'),(25,30,20,'2019-07-25','2029-05-17');
/*!40000 ALTER TABLE `group_of_same_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `invoice` (
  `invoice_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_customer` int(11) DEFAULT NULL,
  `order_date` date NOT NULL,
  `requiered_date` date DEFAULT NULL,
  `ref_user` int(11) NOT NULL,
  `time` time NOT NULL,
  PRIMARY KEY (`invoice_id`),
  KEY `fk_ref_customer_idx` (`ref_customer`),
  KEY `fk_ref_user_idx` (`ref_user`),
  CONSTRAINT `fk_ref_customer1` FOREIGN KEY (`ref_customer`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `fk_ref_user` FOREIGN KEY (`ref_user`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
INSERT INTO `invoice` VALUES (1,4,'2019-05-09','2019-05-09',1,'10:20:00'),(4,4,'2019-05-26','2019-05-26',1,'11:45:00'),(8,3,'2019-05-26','2019-05-26',1,'11:53:31'),(23,3,'2019-05-26','2019-05-26',1,'11:53:31'),(30,2,'2019-05-27','2019-05-27',1,'01:30:31'),(32,3,'2019-06-16','2019-06-16',16,'04:09:12'),(34,6,'2019-06-22','2019-06-22',16,'09:48:29'),(35,NULL,'2019-06-22','2019-06-22',16,'09:52:04'),(36,NULL,'2019-06-23','2019-06-23',16,'09:00:22'),(37,NULL,'2019-06-23','2019-06-23',16,'09:10:05'),(38,NULL,'2019-06-23','2019-06-23',16,'09:15:48'),(39,2,'2019-06-23','2019-06-23',16,'09:17:26'),(40,NULL,'2019-07-08','2019-07-08',1,'08:01:21'),(41,8,'2019-07-10','2019-07-10',23,'08:51:14'),(42,NULL,'2019-07-10','2019-07-10',23,'09:51:49'),(43,NULL,'2019-07-11','2019-07-11',23,'10:09:31'),(44,NULL,'2019-07-10','2019-07-10',23,'11:09:43'),(45,NULL,'2019-07-09','2019-07-09',23,'10:13:29'),(46,NULL,'2019-07-08','2019-07-08',23,'12:13:36'),(47,NULL,'2019-07-07','2019-07-07',23,'17:22:29'),(48,9,'2019-07-06','2019-07-06',23,'20:22:55'),(49,NULL,'2019-07-05','2019-07-05',23,'10:28:51'),(50,NULL,'2019-07-04','2019-07-04',23,'00:31:07'),(51,NULL,'2019-07-03','2019-07-03',23,'10:32:14'),(52,NULL,'2019-07-02','2019-07-02',23,'23:32:44'),(53,NULL,'2019-07-01','2019-07-01',23,'10:34:37'),(54,NULL,'2019-07-12','2019-07-12',19,'07:39:53'),(55,NULL,'2019-07-12','2019-07-12',19,'07:40:29'),(56,NULL,'2019-07-12','2019-07-12',19,'07:40:44'),(57,NULL,'2019-07-12','2019-07-12',21,'07:49:02'),(58,NULL,'2019-07-12','2019-07-12',21,'07:49:12'),(60,NULL,'2019-07-12','2019-07-12',24,'07:53:27'),(61,NULL,'2019-07-12','2019-07-12',23,'07:54:31'),(64,NULL,'2019-07-12','2019-07-12',24,'03:12:35'),(65,NULL,'2019-07-12','2019-07-12',25,'03:26:20'),(66,NULL,'2019-07-12','2019-07-12',25,'03:26:28'),(67,NULL,'2019-07-12','2019-07-12',25,'03:26:36'),(68,NULL,'2019-07-12','2019-07-12',26,'03:30:31'),(69,NULL,'2019-07-12','2019-07-12',26,'03:30:43'),(70,NULL,'2019-07-12','2019-07-12',27,'03:36:18'),(71,NULL,'2019-07-12','2019-07-12',27,'03:36:26'),(72,9,'2019-07-12','2019-07-12',28,'03:42:53'),(73,9,'2019-07-12','2019-07-12',28,'03:43:00'),(74,NULL,'2019-07-25','2019-07-25',30,'07:19:29'),(75,NULL,'2019-07-25','2019-07-25',30,'07:19:43'),(76,NULL,'2019-07-25','2019-07-25',23,'09:04:18'),(77,NULL,'2019-07-25','2019-07-25',23,'10:01:40');
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_contents`
--

DROP TABLE IF EXISTS `invoice_contents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `invoice_contents` (
  `ref_invoice` int(11) NOT NULL,
  `ref_product` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  KEY `fk_ref_invoice_idx` (`ref_invoice`),
  KEY `fk__product3_idx` (`ref_product`),
  CONSTRAINT `fk__product3` FOREIGN KEY (`ref_product`) REFERENCES `product` (`product_id`),
  CONSTRAINT `fk_ref_invoice` FOREIGN KEY (`ref_invoice`) REFERENCES `invoice` (`invoice_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_contents`
--

LOCK TABLES `invoice_contents` WRITE;
/*!40000 ALTER TABLE `invoice_contents` DISABLE KEYS */;
INSERT INTO `invoice_contents` VALUES (1,1,1),(4,1,3),(4,11,4),(8,11,1),(8,1,1),(23,11,1),(23,1,1),(30,11,10),(32,12,1),(35,1,3),(35,13,2),(35,11,1),(35,12,1),(36,1,1),(36,13,2),(37,1,1),(37,12,2),(38,1,1),(38,11,1),(34,1,2),(34,11,1),(34,12,1),(34,13,2),(39,1,3),(40,1,4),(40,11,1),(40,12,2),(40,13,1),(41,14,5),(42,14,2),(43,15,1),(44,15,1),(44,14,1),(45,16,1),(46,15,1),(46,16,1),(46,14,1),(47,17,1),(47,18,1),(48,14,2),(48,17,2),(48,15,1),(48,16,1),(48,18,3),(49,14,1),(49,20,1),(49,19,1),(49,17,1),(50,21,1),(50,18,1),(51,21,8),(52,19,4),(52,20,4),(53,22,20),(54,23,20),(55,23,1),(56,23,8),(57,24,60),(58,24,2),(61,17,1),(61,16,1),(60,25,5),(64,25,5),(65,26,10),(66,26,2),(67,26,5),(68,27,5),(69,27,5),(70,28,4),(71,28,1),(72,29,5),(73,29,1),(74,30,2),(75,30,8),(76,21,100),(76,14,1),(76,15,2),(76,16,1),(76,18,1),(77,21,4),(77,15,1),(77,14,1),(77,22,8),(77,18,1);
/*!40000 ALTER TABLE `invoice_contents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `invoice_prices`
--

DROP TABLE IF EXISTS `invoice_prices`;
/*!50001 DROP VIEW IF EXISTS `invoice_prices`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `invoice_prices` AS SELECT 
 1 AS `invoice_id`,
 1 AS `billbeforeround`,
 1 AS `bill`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `invoicedetails`
--

DROP TABLE IF EXISTS `invoicedetails`;
/*!50001 DROP VIEW IF EXISTS `invoicedetails`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `invoicedetails` AS SELECT 
 1 AS `invoice_id`,
 1 AS `order_date`,
 1 AS `time`,
 1 AS `product_name`,
 1 AS `quantity`,
 1 AS `unit_price`,
 1 AS `per_discount`,
 1 AS `final_price`,
 1 AS `ref_user`,
 1 AS `product_id`,
 1 AS `shop_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `invoiceoperations`
--

DROP TABLE IF EXISTS `invoiceoperations`;
/*!50001 DROP VIEW IF EXISTS `invoiceoperations`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `invoiceoperations` AS SELECT 
 1 AS `shop_id`,
 1 AS `order_date`,
 1 AS `hour`,
 1 AS `product_name`,
 1 AS `quantity`,
 1 AS `final_price`,
 1 AS `profit`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `nbcutindatename`
--

DROP TABLE IF EXISTS `nbcutindatename`;
/*!50001 DROP VIEW IF EXISTS `nbcutindatename`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `nbcutindatename` AS SELECT 
 1 AS `shop_id`,
 1 AS `day`,
 1 AS `nbOfCustomer`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `offer`
--

DROP TABLE IF EXISTS `offer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `offer` (
  `offer_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_product` int(11) NOT NULL,
  `rate_percentage` double NOT NULL DEFAULT '0',
  `description` varchar(45) DEFAULT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  PRIMARY KEY (`offer_id`),
  KEY `fk_ref_product_idx` (`ref_product`),
  CONSTRAINT `fk_ref_product1` FOREIGN KEY (`ref_product`) REFERENCES `product` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offer`
--

LOCK TABLES `offer` WRITE;
/*!40000 ALTER TABLE `offer` DISABLE KEYS */;
INSERT INTO `offer` VALUES (1,1,10,'ramadan','2019-05-06','2019-06-15'),(2,11,5,'fitir eid','2019-05-27','2019-06-15'),(3,1,3,'easter','2019-04-03','2019-04-29'),(4,1,6,'summer1','2019-05-25','2019-06-29'),(5,1,7,'summer2','2019-06-17','2019-08-20'),(6,14,12,'newShop','2019-07-10','2019-07-15'),(7,15,5,'newShop','2019-07-10','2019-07-10'),(8,16,3,'newShop','2019-07-10','2019-07-10'),(9,18,5,'newShop','2019-07-10','2019-07-27'),(10,30,11,'spring1','2019-07-25','2019-07-29');
/*!40000 ALTER TABLE `offer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `online_customer`
--

DROP TABLE IF EXISTS `online_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `online_customer` (
  `ref_customer` int(11) NOT NULL,
  `user_name` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `ref_full_address` int(11) NOT NULL,
  `email` varchar(60) NOT NULL,
  PRIMARY KEY (`ref_customer`),
  UNIQUE KEY `u_account` (`password`,`user_name`) /*!80000 INVISIBLE */,
  UNIQUE KEY `ref_full_address_UNIQUE` (`ref_full_address`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `fk_ref_full_address_idx` (`ref_full_address`),
  CONSTRAINT `fk_ref_customer` FOREIGN KEY (`ref_customer`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `fk_ref_full_address` FOREIGN KEY (`ref_full_address`) REFERENCES `full_address` (`full_adress_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `online_customer`
--

LOCK TABLES `online_customer` WRITE;
/*!40000 ALTER TABLE `online_customer` DISABLE KEYS */;
INSERT INTO `online_customer` VALUES (3,'BorhanDernayka','987654321',8,'bourhandernayaa@gmail.com');
/*!40000 ALTER TABLE `online_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `person` (
  `person_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(10) NOT NULL,
  `last_name` varchar(10) NOT NULL,
  `ref_address` int(11) NOT NULL,
  PRIMARY KEY (`person_id`),
  UNIQUE KEY `u_name` (`first_name`,`last_name`) /*!80000 INVISIBLE */,
  KEY `fk_ref_address_idx` (`ref_address`),
  CONSTRAINT `fk_ref_address` FOREIGN KEY (`ref_address`) REFERENCES `address` (`adress_id`)
) ENGINE=InnoDB AUTO_INCREMENT=128 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (22,'mohamad','abdallah',1),(23,'mahmoud','abdallah',1),(25,'ibrahim','jazzar',2),(26,'bourhan','dernayka',5),(79,'raghad','abdallah',109),(108,'omar','abdallah',1),(110,'unknownF','-',182),(113,'adnan','wazzeh',5),(114,'fadwa','daana',1),(117,'alaa','abdallah',1),(118,'mahmoud','daana',1),(119,'bader','dib',1),(120,'rouayda','dib',1),(121,'bachir','eldaya',211),(122,'rayan','tout',212),(123,'joseph','saba',7),(124,'jamil','khabbaz',5),(125,'adnan','obeid',5),(126,'elias','bousaab',224),(127,'samir','mohsen',232);
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_shop` int(11) NOT NULL,
  `product_name` varchar(45) NOT NULL,
  `purchase_price` double NOT NULL,
  `unit_price` double NOT NULL,
  `picture` varchar(45) DEFAULT NULL,
  `ref_supplier` int(11) NOT NULL,
  `quantity_per_unit` int(11) NOT NULL DEFAULT '1',
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_id`),
  UNIQUE KEY `name_UNIQUE` (`product_name`),
  KEY `fk_ref_shop_idx` (`ref_shop`),
  KEY `fk_ref_supplire_idx` (`ref_supplier`),
  CONSTRAINT `fk_ref_shop1` FOREIGN KEY (`ref_shop`) REFERENCES `shop` (`shop_id`),
  CONSTRAINT `fk_ref_supplier` FOREIGN KEY (`ref_supplier`) REFERENCES `supplier` (`supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,1,'shoes2019',10,30,'shoes2019',1,1,'20-41'),(2,2,'unknownP',0,0,'product',2,0,'-'),(11,1,'shoes2010',20,20,'shoes2010',1,1,'38-45'),(12,1,'lacosteShoes',20,30,'lacosteShoes',5,1,'43-55'),(13,1,'sandals2010',10,15,'sandals2010',4,1,'20-50'),(14,8,'coffeeNajjar',1,2,'coffeeNajjar',6,1,'hotCoffe'),(15,8,'nescafe',5,10,'nescafe',6,1,'coffe'),(16,8,'capoccino',6,11,'capoccino',6,1,'coffe'),(17,8,'teaLipton',1,5,'teaLipton',7,1,'hot'),(18,8,'liptonJus',5,15,'liptonJus',7,1,'coldJus'),(19,8,'pepsi_tank',1,2,'pepsi_tank',8,1,'cold'),(20,8,'pepsiDiet',1,3,'pepsiDiet',8,1,'coldAndHealth'),(21,8,'miranda',1,2,'miranda',8,1,'cold'),(22,8,'sevenUPTank',1,3,'sevenUPTank',8,1,'cold'),(23,5,'orange',5,7,'orange',9,1,'kiloOfOrange'),(24,10,'mimosaTissu',2,5,'mimosaTissu',10,1,'box'),(25,11,'toy',20,30,'toy',11,1,'forGirl'),(26,7,'orangeJus',3,5,'orangeJus',12,1,'cold'),(27,6,'shortNike',10,30,'shortNike',4,1,'goalShort'),(28,9,'kaiulSunGlasses',10,50,'kaiulSunGlasses',13,1,'vsSun'),(29,4,'SportSuit',20,30,'SportSuit',1,1,'forBasketBall'),(30,12,'oiseau',10,13,'oiseau',14,1,'fly');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `product_details`
--

DROP TABLE IF EXISTS `product_details`;
/*!50001 DROP VIEW IF EXISTS `product_details`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `product_details` AS SELECT 
 1 AS `product_id`,
 1 AS `product_name`,
 1 AS `description`,
 1 AS `ref_shop`,
 1 AS `purchase_price`,
 1 AS `unit_price`,
 1 AS `picture`,
 1 AS `ref_supplier`,
 1 AS `quantity_per_unit`,
 1 AS `rate_percentage`,
 1 AS `discountType`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `product_prices`
--

DROP TABLE IF EXISTS `product_prices`;
/*!50001 DROP VIEW IF EXISTS `product_prices`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `product_prices` AS SELECT 
 1 AS `ref_product`,
 1 AS `product_name`,
 1 AS `shop_id`,
 1 AS `final_price`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `productpurchased`
--

DROP TABLE IF EXISTS `productpurchased`;
/*!50001 DROP VIEW IF EXISTS `productpurchased`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `productpurchased` AS SELECT 
 1 AS `ref_shop`,
 1 AS `product_name`,
 1 AS `product_id`,
 1 AS `picture`,
 1 AS `purchased`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `realemployee`
--

DROP TABLE IF EXISTS `realemployee`;
/*!50001 DROP VIEW IF EXISTS `realemployee`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `realemployee` AS SELECT 
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `employee_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `saledproducts`
--

DROP TABLE IF EXISTS `saledproducts`;
/*!50001 DROP VIEW IF EXISTS `saledproducts`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `saledproducts` AS SELECT 
 1 AS `ref_shop`,
 1 AS `product_name`,
 1 AS `product_id`,
 1 AS `sailed`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `shop`
--

DROP TABLE IF EXISTS `shop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shop` (
  `shop_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_admin` int(11) NOT NULL,
  `profile` varchar(45) DEFAULT NULL,
  `ref_category` int(11) NOT NULL,
  `floor` int(11) NOT NULL,
  `shop_name` varchar(45) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`shop_id`),
  UNIQUE KEY `shop_name_UNIQUE` (`shop_name`),
  KEY `fk_ref_admin_idx` (`ref_admin`),
  KEY `fk_ref_category_idx` (`ref_category`),
  CONSTRAINT `fk_ref_admin` FOREIGN KEY (`ref_admin`) REFERENCES `adminstrator` (`admin_id`),
  CONSTRAINT `fk_ref_category` FOREIGN KEY (`ref_category`) REFERENCES `category` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shop`
--

LOCK TABLES `shop` WRITE;
/*!40000 ALTER TABLE `shop` DISABLE KEYS */;
INSERT INTO `shop` VALUES (1,3,'MAShoes',1,3,'MAShoes','allTypeOfShoes'),(2,3,'shop',10,0,'unknownS','-'),(4,3,'sportswear',1,4,'sportswear','allSportWears'),(5,3,'MAFruits',11,2,'MAFruits','allFruits'),(6,31,'MAClothes',1,4,'MAClothes','forChildrenToOldHumans'),(7,31,'freshJus',13,3,'freshJus','bananas,orange,others'),(8,31,'cafe',13,1,'cafe','nescafe,tea,others'),(9,31,'MAGlasses',14,1,'MAGlasses','sunGlasses,others'),(10,31,'betterHouse',15,2,'betterHouse','letYourHouseClean'),(11,31,'childEnjoyment',12,3,'childEnjoyment','gamesForChildren'),(12,37,'Parrot',19,1,'Parrot','selling\rs');
/*!40000 ALTER TABLE `shop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `shop_nbuser`
--

DROP TABLE IF EXISTS `shop_nbuser`;
/*!50001 DROP VIEW IF EXISTS `shop_nbuser`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `shop_nbuser` AS SELECT 
 1 AS `shop_name`,
 1 AS `nbuser`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `shop_prices`
--

DROP TABLE IF EXISTS `shop_prices`;
/*!50001 DROP VIEW IF EXISTS `shop_prices`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `shop_prices` AS SELECT 
 1 AS `shop_name`,
 1 AS `prices`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `shop_products`
--

DROP TABLE IF EXISTS `shop_products`;
/*!50001 DROP VIEW IF EXISTS `shop_products`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `shop_products` AS SELECT 
 1 AS `shop_id`,
 1 AS `shop_name`,
 1 AS `product_id`,
 1 AS `product_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `shop_supplier`
--

DROP TABLE IF EXISTS `shop_supplier`;
/*!50001 DROP VIEW IF EXISTS `shop_supplier`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `shop_supplier` AS SELECT 
 1 AS `shop_name`,
 1 AS `supplier_name`,
 1 AS `shop_id`,
 1 AS `product_name`,
 1 AS `group_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `shop_user`
--

DROP TABLE IF EXISTS `shop_user`;
/*!50001 DROP VIEW IF EXISTS `shop_user`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `shop_user` AS SELECT 
 1 AS `shop_name`,
 1 AS `user`,
 1 AS `user_id`,
 1 AS `shop_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `supplier` (
  `supplier_id` int(11) NOT NULL AUTO_INCREMENT,
  `supplier_name` varchar(45) NOT NULL,
  `profile` varchar(45) DEFAULT NULL,
  `ref_address` int(11) NOT NULL,
  `ref_full_address` int(11) NOT NULL,
  `fax` varchar(45) NOT NULL,
  `web_page` varchar(45) NOT NULL,
  PRIMARY KEY (`supplier_id`),
  UNIQUE KEY `supplier_name_UNIQUE` (`supplier_name`),
  UNIQUE KEY `fax_UNIQUE` (`fax`),
  UNIQUE KEY `web_page_UNIQUE` (`web_page`),
  KEY `fk_ref_address1_idx` (`ref_address`),
  KEY `fk_ref_full_address1_idx` (`ref_full_address`),
  CONSTRAINT `fk_ref_address1` FOREIGN KEY (`ref_address`) REFERENCES `address` (`adress_id`),
  CONSTRAINT `fk_ref_full_address1` FOREIGN KEY (`ref_full_address`) REFERENCES `full_address` (`full_adress_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'adidas','adidas',4,9,'96419648','https://www.adidas.de/'),(2,'unknownS','supplier',182,64,'0\r00','-'),(4,'nike','nike',4,66,'as68c','https://www.nike.com'),(5,'lacoste','lacoste',4,75,'ravbdb8648','https://global.lacoste.com'),(6,'najjar','najjar',4,76,'5648848','najjar.com'),(7,'Lipton','Lipton',4,77,'saef','www.lipton.com'),(8,'pepsi','pepsi',5,78,'aefew','pepsi.org'),(9,'sou2el5edra','sou2el5edra',226,79,'54188','www.sou25edra.com'),(10,'Mimosa','Mimosa',5,80,'asf849','www.mimosa.com'),(11,'toys','toys',224,81,'segver','toys.com'),(12,'kokteilElFarah','kokteilElFarah',5,82,'165484','www.kokteilFarah.com'),(13,'kaiul','kaiul',230,83,'ergver','www.kaiul.com'),(14,'amazon','amazon',234,85,'sef541','www.amazon.com');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `supplierinfo`
--

DROP TABLE IF EXISTS `supplierinfo`;
/*!50001 DROP VIEW IF EXISTS `supplierinfo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `supplierinfo` AS SELECT 
 1 AS `supplier_id`,
 1 AS `supplier_name`,
 1 AS `fax`,
 1 AS `country`,
 1 AS `city`,
 1 AS `profile`,
 1 AS `web_page`,
 1 AS `street`,
 1 AS `building`,
 1 AS `floor`,
 1 AS `door_id`,
 1 AS `postal_code`,
 1 AS `phone_number`,
 1 AS `full_adress_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `ref_employee` int(11) NOT NULL,
  `ref_admin` int(11) NOT NULL,
  `ref_shop` int(11) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `ref_employee_UNIQUE` (`ref_employee`),
  KEY `fk_ref_employee_idx` (`ref_employee`),
  KEY `fk_ref_admin_idx` (`ref_admin`),
  KEY `fk_ref_shop_idx` (`ref_shop`),
  CONSTRAINT `fk_ref_admin1` FOREIGN KEY (`ref_admin`) REFERENCES `adminstrator` (`admin_id`),
  CONSTRAINT `fk_ref_employee2` FOREIGN KEY (`ref_employee`) REFERENCES `employee` (`employee_id`),
  CONSTRAINT `fk_ref_shop` FOREIGN KEY (`ref_shop`) REFERENCES `shop` (`shop_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,1,3,1),(16,37,3,1),(17,39,35,2),(18,28,3,1),(19,40,3,5),(20,2,34,1),(21,41,34,10),(23,42,34,8),(24,43,34,11),(25,44,34,7),(26,45,34,6),(27,46,34,9),(28,47,34,4),(30,48,37,12);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `useraccounts`
--

DROP TABLE IF EXISTS `useraccounts`;
/*!50001 DROP VIEW IF EXISTS `useraccounts`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `useraccounts` AS SELECT 
 1 AS `user_name`,
 1 AS `password`,
 1 AS `user_id`,
 1 AS `employee_id`,
 1 AS `ref_shop`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'ma_mall'
--

--
-- Dumping routines for database 'ma_mall'
--
/*!50003 DROP FUNCTION IF EXISTS `shopIdOfUserId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `shopIdOfUserId`(userIdOr0 int) RETURNS int(11)
    DETERMINISTIC
BEGIN
declare shopId int  ;
select shop_user.shop_id into shopId from shop_user where shop_user.user_id = userIdOr0;
RETURN shopId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `avgCustByHoursInAShop` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `avgCustByHoursInAShop`(userID int)
BEGIN
declare shopId int;
select shopIdOfUserId(userID) into shopId;
SELECT hour, round(avg( nbOfCustomer)) as nbOfCustomerAvg FROM distributionofcustomerondatehour 
where shop_id=shopId
group by shop_id,hour
order by shop_id,hour ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `categoriesWithNbShops` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `categoriesWithNbShops`(in cId int)
BEGIN
if cId =0 then
   SELECT 
        `category`.`category_name` AS `category_name`,
        COUNT(`shop`.`shop_name`) AS `nbshop`
    FROM
        (`category`
        LEFT JOIN `shop` ON ((`category`.`category_id` = `shop`.`ref_category`)))
                        where `category`.`category_id`!=10 
    GROUP BY `category`.`category_name`;
else
 SELECT 
        `category`.`category_name` AS `category_name`,
        COUNT(`shop`.`shop_name`) AS `nbshop`
    FROM
        (`category`
        LEFT JOIN `shop` ON ((`category`.`category_id` = `shop`.`ref_category`)))
                where `category`.`category_id`=cId 
    GROUP BY `category`.`category_name`;
end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `categoriesWithShops` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `categoriesWithShops`(in cIdOR0ForAllCategories int )
BEGIN
if cIdOR0ForAllCategories=0 then
    SELECT 
        `category`.`category_name` AS `category_name`,
        COALESCE(`shop`.`shop_name`, '-') AS `shop_name`
    FROM
        (`category`
        LEFT JOIN `shop` ON ((`category`.`category_id` = `shop`.`ref_category`)))
        where `category`.`category_id` !=10
    ORDER BY `category`.`category_name`;
else
 SELECT 
        `category`.`category_name` AS `category_name`,
        COALESCE(`shop`.`shop_name`, '-') AS `shop_name`
    FROM
        (`category`
        LEFT JOIN `shop` ON ((`category`.`category_id` = `shop`.`ref_category`)))
	where `category`.`category_id` =cIdOR0ForAllCategories
    ORDER BY `category`.`category_name`;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `customerInShopInWeek` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `customerInShopInWeek`(userId int)
BEGIN
declare shopId int;
select shopIdOfUserId(userId) into shopId;
SELECT   
CASE
    WHEN day = 0 THEN "Monday"
    WHEN day = 1 THEN "Tuesday"
        WHEN day = 2 THEN "Wednesday"
    WHEN day = 3 THEN "Thursday"
   WHEN day = 4 THEN "Friday"
    WHEN day = 5 THEN "Saturday"
    WHEN day = 6 THEN "Sunday"
END
as weekday, round(avg(nbOfCustomer))  as nbOfCustomerAvg FROM nbcutindatename
where shop_id=shopId
group by shop_id,day
order by shop_id,day;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `deleteCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteCategory`(in categoryId int)
BEGIN
update shop set shop.ref_category='10' where shop.ref_category=categoryId;
delete from category where category_id=categoryId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `distributionofcustomerondatename` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `distributionofcustomerondatename`(userID int)
BEGIN
declare shopId int;
select shopIdOfUserId(userID) into shopId;
SELECT dayname(order_date) as day,round(avg(nbOfCustomer)) as nbOfCustomer FROM distributionofcustomerondatehour
where shop_id=shopId
group by shop_id,day;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `employeeInfoForAShopOrAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `employeeInfoForAShopOrAll`(userIDOr0 int)
BEGIN
declare shopId int;
if userIDOr0=0 then
select concat(first_name," ", last_name) as name, country, city, birth_date, postal_code, phone_number, hire_date, fix_salary, email from employeeinfo ;
else
select  ma_mall.shopIdOfUserId(userIDOr0) into shopId;
select concat(first_name," ", last_name) as name, country, city, birth_date, postal_code, phone_number, hire_date, fix_salary, email from employeeinfo where ma_mall.shopIdOfUserId(user_id) = shopId;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getCategoryInf` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCategoryInf`(in categoryId int)
BEGIN
select category_name,description,profile,ref_admin,category_id from category where category_id=categoryId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getCategoryNamesWithId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCategoryNamesWithId`()
BEGIN
select category_name,category_id from category  where category.category_id!=10;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertCategory`(IN  cName varchar(20),IN cDescription varchar(100),IN cProfile varchar(45),IN cAdmin int(11))
begin
insert into category (category.category_name,category.description,category.profile,category.ref_admin) values(cName,cDescription,cProfile,cAdmin);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ProductInStock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductInStock`(userID int)
BEGIN
declare shopId int;
select ma_mall.shopIdOfUserId(userID)into shopId ;
select Productpurchased.product_name,Productpurchased.picture,purchased-sailed as availableInStock  from Productpurchased
left outer join saledProducts on Productpurchased.product_id=saledProducts.product_id
where Productpurchased.ref_shop=shopId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `productOperations` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `productOperations`(userId int)
BEGIN
declare shopId int;
select shopIdOfUserId(userId) into shopId;
select order_date,hour,product_name,quantity,concat('$',' ',round(final_price)) as final_price,concat('$',' ',round( profit ))as final_price from invoiceoperations where shop_id=shopId; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `productsWithPricesInAShop` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `productsWithPricesInAShop`(IN  userID int )
begin 
select product_prices.product_name,concat('$',' ',product_prices.final_price) as final_price from product_prices where product_prices.shop_id=(select shop_user.shop_id from shop_user where shop_user.user_id =userID);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `productsWithPricesInAShopSD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `productsWithPricesInAShopSD`(IN  userID int )
begin 
select product_prices.product_name,concat(product_prices.final_price) as final_price from product_prices where product_prices.shop_id=(select shop_user.shop_id from shop_user where shop_user.user_id =userID);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `salariesInShops` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `salariesInShops`(in shopIdOr0ForAll int,in userIdOr0IfNoUser int)
BEGIN
if shopIdOr0ForAll=0 and userIdOr0IfNoUser=0 then 
select concat(employeeinfo.first_name," ",employeeinfo.last_name) as name , shop_user.shop_name,employeeinfo.fix_salary,(year(current_date())-year(employeeinfo.hire_date)) as nbOfWorkYear ,employeeinfo.married,employeeinfo.nb_children,concat('$',"   ",fix_salary+(year(current_date())-year(employeeinfo.hire_date))*50+ married*50+nb_children*20) as monthSalary from employeeinfo
left outer join shop_user on employeeinfo.user_id = shop_user.user_id
where employeeinfo.employee_id !='39' and employeeinfo.user_id is not null 
order by name;
elseif shopIdOr0ForAll=0 and userIdOr0IfNoUser!=0 then
select concat(employeeinfo.first_name," ",employeeinfo.last_name) as name /*, shop_user.shop_name*/,employeeinfo.fix_salary,(year(current_date())-year(employeeinfo.hire_date)) as nbOfWorkYear ,employeeinfo.married,employeeinfo.nb_children,concat('$',"   ",fix_salary+(year(current_date())-year(employeeinfo.hire_date))*50+ married*50+nb_children*20) as monthSalary from employeeinfo
left outer join shop_user on employeeinfo.user_id = shop_user.user_id
where employeeinfo.employee_id !='39' and employeeinfo.user_id is not null and shop_user.shop_id=(select shop_user.shop_id from shop_user where shop_user.user_id =userIdOr0IfNoUser)
order by name;
else
select concat(employeeinfo.first_name," ",employeeinfo.last_name) as name /*, shop_user.shop_name*/,employeeinfo.fix_salary,(year(current_date())-year(employeeinfo.hire_date)) as nbOfWorkYear ,employeeinfo.married,employeeinfo.nb_children,concat('$',"   ",fix_salary+(year(current_date())-year(employeeinfo.hire_date))*50+ married*50+nb_children*20) as monthSalary from employeeinfo
left outer join shop_user on employeeinfo.user_id = shop_user.user_id
where employeeinfo.employee_id !='39' and employeeinfo.user_id is not null  and shop_user.shop_id=shopIdOr0ForAll
order by name;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ShopGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ShopGroup`( userId int)
BEGIN
declare  shopId int;
select ma_mall.shopIdOfUserId(userId) into shopId;
select group_id,product_name, quantity, date_of_buy, expiration_date, picture from group_of_same_product 
left outer join product on ref_product=product_id
where ref_shop=shopId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `shopsSuppliersProducts` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `shopsSuppliersProducts`(IN  shopIDOr0ForAllShops int )
begin
if shopIDOr0ForAllShops !='0' then 
	(select shop_supplier.shop_name,shop_supplier.supplier_name,shop_supplier.product_name from shop_supplier
	where shop_id=shopIDOr0ForAllShops
	group by shop_supplier.shop_name,shop_supplier.supplier_name,shop_supplier.product_name);
else
	(select shop_supplier.shop_name,shop_supplier.supplier_name,shop_supplier.product_name from shop_supplier
	where shop_supplier.shop_name!='unknownS'
    group by shop_supplier.shop_name,shop_supplier.supplier_name,shop_supplier.product_name);
end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `updateCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateCategory`(IN  cName varchar(20),IN cDescription varchar(100),IN cProfile varchar(45),in cId int)
BEGIN
update category set category_name=cName,description=cDescription,profile=cProfile where category_id=cId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `adminaccounts`
--

/*!50001 DROP VIEW IF EXISTS `adminaccounts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `adminaccounts` AS select `employee`.`user_name` AS `user_name`,`employee`.`password` AS `password`,`adminstrator`.`admin_id` AS `admin_id`,`employee`.`employee_id` AS `employee_id` from (`employee` join `adminstrator` on((`employee`.`employee_id` = `adminstrator`.`ref_employee`))) where (not(`employee`.`employee_id` in (select `ancien_employee`.`ref_employee` from `ancien_employee`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `category_nbshop`
--

/*!50001 DROP VIEW IF EXISTS `category_nbshop`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `category_nbshop` AS select `category`.`category_name` AS `category_name`,count(`shop`.`shop_name`) AS `nbshop` from (`category` left join `shop` on((`category`.`category_id` = `shop`.`ref_category`))) where (`category`.`category_id` <> 10) group by `category`.`category_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `category_shop`
--

/*!50001 DROP VIEW IF EXISTS `category_shop`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `category_shop` AS select `category`.`category_name` AS `category_name`,coalesce(`shop`.`shop_name`,'-') AS `shop_name` from (`category` left join `shop` on((`category`.`category_id` = `shop`.`ref_category`))) where (`category`.`category_id` <> 10) order by `category`.`category_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `customerinfo`
--

/*!50001 DROP VIEW IF EXISTS `customerinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `customerinfo` AS select `person`.`first_name` AS `first_name`,`person`.`last_name` AS `last_name`,`address`.`country` AS `country`,`address`.`city` AS `city`,`person`.`person_id` AS `person_id`,`customer`.`customer_id` AS `customer_id` from ((`person` join `address`) join `customer` on(((`person`.`ref_address` = `address`.`adress_id`) and (`customer`.`ref_person` = `person`.`person_id`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `customertimedistributionindays`
--

/*!50001 DROP VIEW IF EXISTS `customertimedistributionindays`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `customertimedistributionindays` AS select hour(`invoice`.`time`) AS `hour`,`invoice`.`order_date` AS `order_date`,count(`invoice`.`invoice_id`) AS `nbCustomer` from `invoice` group by hour(`invoice`.`time`) order by `invoice`.`order_date` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `customertimedistributioninweekdays`
--

/*!50001 DROP VIEW IF EXISTS `customertimedistributioninweekdays`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `customertimedistributioninweekdays` AS select hour(`invoice`.`time`) AS `hour`,dayname(`invoice`.`order_date`) AS `day`,count(`invoice`.`invoice_id`) AS `nbCustomer` from `invoice` group by hour(`invoice`.`time`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `distributionofcustomerondatehour`
--

/*!50001 DROP VIEW IF EXISTS `distributionofcustomerondatehour`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `distributionofcustomerondatehour` AS select `invoiceoperations`.`shop_id` AS `shop_id`,`invoiceoperations`.`order_date` AS `order_date`,`invoiceoperations`.`hour` AS `hour`,count(`invoiceoperations`.`shop_id`) AS `nbOfCustomer` from `invoiceoperations` group by `invoiceoperations`.`shop_id`,`invoiceoperations`.`hour`,`invoiceoperations`.`order_date` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `employeeinfo`
--

/*!50001 DROP VIEW IF EXISTS `employeeinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `employeeinfo` AS select `employee`.`employee_id` AS `employee_id`,`person`.`first_name` AS `first_name`,`person`.`last_name` AS `last_name`,`address`.`country` AS `country`,`address`.`city` AS `city`,`employee`.`birth_date` AS `birth_date`,`employee`.`profile` AS `profile`,`employee`.`user_name` AS `user_name`,`employee`.`password` AS `password`,`full_address`.`street` AS `street`,`full_address`.`building` AS `building`,`full_address`.`floor` AS `floor`,`full_address`.`door_id` AS `door_id`,`full_address`.`postal_code` AS `postal_code`,`full_address`.`phone_number` AS `phone_number`,`employee`.`hire_date` AS `hire_date`,`employee`.`fix_salary` AS `fix_salary`,`employee`.`married` AS `married`,`employee`.`nb_children` AS `nb_children`,`employee`.`email` AS `email`,`person`.`person_id` AS `person_id`,`full_address`.`full_adress_id` AS `full_adress_id`,`user`.`user_id` AS `user_id`,`adminstrator`.`admin_id` AS `admin_id` from (((((`person` join `address`) join `employee`) join `full_address` on(((`address`.`adress_id` = `person`.`ref_address`) and (`employee`.`ref_person` = `person`.`person_id`) and (`full_address`.`full_adress_id` = `employee`.`ref_full_address`)))) left join `user` on((`employee`.`employee_id` = `user`.`ref_employee`))) left join `adminstrator` on((`adminstrator`.`ref_employee` = `employee`.`employee_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `invoice_prices`
--

/*!50001 DROP VIEW IF EXISTS `invoice_prices`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `invoice_prices` AS select `invoicedetails`.`invoice_id` AS `invoice_id`,sum(`invoicedetails`.`final_price`) AS `billbeforeround`,round(sum(`invoicedetails`.`final_price`),0) AS `bill` from `invoicedetails` group by `invoicedetails`.`invoice_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `invoicedetails`
--

/*!50001 DROP VIEW IF EXISTS `invoicedetails`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `invoicedetails` AS select `invoice`.`invoice_id` AS `invoice_id`,`invoice`.`order_date` AS `order_date`,`invoice`.`time` AS `time`,`product`.`product_name` AS `product_name`,`invoice_contents`.`quantity` AS `quantity`,`product`.`unit_price` AS `unit_price`,coalesce(sum(`offer`.`rate_percentage`),0) AS `per_discount`,(((`invoice_contents`.`quantity` * 0.01) * (100 - coalesce(sum(`offer`.`rate_percentage`),0))) * `product`.`unit_price`) AS `final_price`,`invoice`.`ref_user` AS `ref_user`,`product`.`product_id` AS `product_id`,`shop_user`.`shop_id` AS `shop_id` from ((((`invoice` join `invoice_contents` on((`invoice`.`invoice_id` = `invoice_contents`.`ref_invoice`))) join `product` on((`product`.`product_id` = `invoice_contents`.`ref_product`))) left join `offer` on(((`offer`.`ref_product` = `product`.`product_id`) and (`invoice`.`order_date` between `offer`.`start_date` and `offer`.`end_date`)))) join `shop_user` on((`shop_user`.`user_id` = `invoice`.`ref_user`))) group by `invoice`.`invoice_id`,`product`.`product_id` order by `invoice`.`invoice_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `invoiceoperations`
--

/*!50001 DROP VIEW IF EXISTS `invoiceoperations`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `invoiceoperations` AS select `invoicedetails`.`shop_id` AS `shop_id`,`invoicedetails`.`order_date` AS `order_date`,hour(`invoicedetails`.`time`) AS `hour`,`invoicedetails`.`product_name` AS `product_name`,`invoicedetails`.`quantity` AS `quantity`,`invoicedetails`.`final_price` AS `final_price`,(`invoicedetails`.`final_price` - (`invoicedetails`.`quantity` * `product`.`purchase_price`)) AS `profit` from (`invoicedetails` left join `product` on((`product`.`product_name` = `invoicedetails`.`product_name`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `nbcutindatename`
--

/*!50001 DROP VIEW IF EXISTS `nbcutindatename`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nbcutindatename` AS select `distributionofcustomerondatehour`.`shop_id` AS `shop_id`,weekday(`distributionofcustomerondatehour`.`order_date`) AS `day`,round(sum(`distributionofcustomerondatehour`.`nbOfCustomer`),0) AS `nbOfCustomer` from `distributionofcustomerondatehour` group by `distributionofcustomerondatehour`.`shop_id`,`distributionofcustomerondatehour`.`order_date` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `product_details`
--

/*!50001 DROP VIEW IF EXISTS `product_details`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `product_details` AS select `product`.`product_id` AS `product_id`,`product`.`product_name` AS `product_name`,`product`.`description` AS `description`,`product`.`ref_shop` AS `ref_shop`,`product`.`purchase_price` AS `purchase_price`,`product`.`unit_price` AS `unit_price`,`product`.`picture` AS `picture`,`product`.`ref_supplier` AS `ref_supplier`,`product`.`quantity_per_unit` AS `quantity_per_unit`,sum(`offer`.`rate_percentage`) AS `rate_percentage`,group_concat(`offer`.`description` separator ',') AS `discountType` from (`product` left join `offer` on(((`product`.`product_id` = `offer`.`ref_product`) and (curdate() between `offer`.`start_date` and `offer`.`end_date`)))) group by `product`.`product_id` order by `product`.`ref_shop` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `product_prices`
--

/*!50001 DROP VIEW IF EXISTS `product_prices`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `product_prices` AS select `invoice_contents`.`ref_product` AS `ref_product`,`product`.`product_name` AS `product_name`,`shop_user`.`shop_id` AS `shop_id`,sum((((0.01 * `invoice_contents`.`quantity`) * (100 - coalesce(`offer`.`rate_percentage`,0))) * `product`.`unit_price`)) AS `final_price` from ((((`invoice_contents` left join `product` on((`product`.`product_id` = `invoice_contents`.`ref_product`))) left join `invoice` on((`invoice`.`invoice_id` = `invoice_contents`.`ref_invoice`))) left join `offer` on(((`offer`.`ref_product` = `invoice_contents`.`ref_product`) and (`invoice`.`order_date` between `offer`.`start_date` and `offer`.`end_date`)))) left join `shop_user` on((`shop_user`.`user_id` = `invoice`.`ref_user`))) group by `product`.`product_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `productpurchased`
--

/*!50001 DROP VIEW IF EXISTS `productpurchased`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `productpurchased` AS select `product`.`ref_shop` AS `ref_shop`,`product`.`product_name` AS `product_name`,`product`.`product_id` AS `product_id`,`product`.`picture` AS `picture`,sum(`group_of_same_product`.`quantity`) AS `purchased` from (`product` left join `group_of_same_product` on((`product`.`product_id` = `group_of_same_product`.`ref_product`))) group by `group_of_same_product`.`ref_product` order by `product`.`ref_shop`,`product`.`product_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `realemployee`
--

/*!50001 DROP VIEW IF EXISTS `realemployee`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `realemployee` AS select `person`.`first_name` AS `first_name`,`person`.`last_name` AS `last_name`,`employee`.`employee_id` AS `employee_id` from (`person` join `employee` on((`person`.`person_id` = `employee`.`ref_person`))) where (not(`employee`.`employee_id` in (select `ancien_employee`.`ref_employee` from `ancien_employee`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `saledproducts`
--

/*!50001 DROP VIEW IF EXISTS `saledproducts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `saledproducts` AS select `product`.`ref_shop` AS `ref_shop`,`product`.`product_name` AS `product_name`,`product`.`product_id` AS `product_id`,sum(`invoice_contents`.`quantity`) AS `sailed` from (`invoice_contents` left join `product` on((`product`.`product_id` = `invoice_contents`.`ref_product`))) group by `invoice_contents`.`ref_product` order by `product`.`ref_shop`,`product`.`product_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `shop_nbuser`
--

/*!50001 DROP VIEW IF EXISTS `shop_nbuser`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `shop_nbuser` AS select `shop`.`shop_name` AS `shop_name`,count(`user`.`user_id`) AS `nbuser` from (`shop` left join `user` on((`user`.`ref_shop` = `shop`.`shop_id`))) group by `shop`.`shop_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `shop_prices`
--

/*!50001 DROP VIEW IF EXISTS `shop_prices`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `shop_prices` AS select `shop`.`shop_name` AS `shop_name`,coalesce(sum(`invoicedetails`.`final_price`),0) AS `prices` from (`shop` left join `invoicedetails` on((`shop`.`shop_id` = `invoicedetails`.`shop_id`))) group by `shop`.`shop_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `shop_products`
--

/*!50001 DROP VIEW IF EXISTS `shop_products`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `shop_products` AS select `shop`.`shop_id` AS `shop_id`,`shop`.`shop_name` AS `shop_name`,`product`.`product_id` AS `product_id`,`product`.`product_name` AS `product_name` from (`shop` left join `product` on((`shop`.`shop_id` = `product`.`ref_shop`))) order by `shop`.`shop_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `shop_supplier`
--

/*!50001 DROP VIEW IF EXISTS `shop_supplier`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `shop_supplier` AS select distinct `shop`.`shop_name` AS `shop_name`,`supplier`.`supplier_name` AS `supplier_name`,`shop`.`shop_id` AS `shop_id`,`product`.`product_name` AS `product_name`,`group_of_same_product`.`group_id` AS `group_id` from (((`shop` left join `product` on((`product`.`ref_shop` = `shop`.`shop_id`))) left join `supplier` on((`supplier`.`supplier_id` = `product`.`ref_supplier`))) left join `group_of_same_product` on((`group_of_same_product`.`ref_product` = `product`.`product_id`))) order by `shop`.`shop_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `shop_user`
--

/*!50001 DROP VIEW IF EXISTS `shop_user`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `shop_user` AS select `shop`.`shop_name` AS `shop_name`,concat(`person`.`first_name`,' ',`person`.`last_name`) AS `user`,`user`.`user_id` AS `user_id`,`shop`.`shop_id` AS `shop_id` from (((`shop` left join `user` on((`user`.`ref_shop` = `shop`.`shop_id`))) left join `employee` on((`user`.`ref_employee` = `employee`.`employee_id`))) left join `person` on((`person`.`person_id` = `employee`.`ref_person`))) order by `shop`.`shop_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `supplierinfo`
--

/*!50001 DROP VIEW IF EXISTS `supplierinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `supplierinfo` AS select `supplier`.`supplier_id` AS `supplier_id`,`supplier`.`supplier_name` AS `supplier_name`,`supplier`.`fax` AS `fax`,`address`.`country` AS `country`,`address`.`city` AS `city`,`supplier`.`profile` AS `profile`,`supplier`.`web_page` AS `web_page`,`full_address`.`street` AS `street`,`full_address`.`building` AS `building`,`full_address`.`floor` AS `floor`,`full_address`.`door_id` AS `door_id`,`full_address`.`postal_code` AS `postal_code`,`full_address`.`phone_number` AS `phone_number`,`full_address`.`full_adress_id` AS `full_adress_id` from ((`supplier` join `address`) join `full_address` on(((`supplier`.`ref_address` = `address`.`adress_id`) and (`supplier`.`ref_full_address` = `full_address`.`full_adress_id`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `useraccounts`
--

/*!50001 DROP VIEW IF EXISTS `useraccounts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `useraccounts` AS select `employee`.`user_name` AS `user_name`,`employee`.`password` AS `password`,`user`.`user_id` AS `user_id`,`employee`.`employee_id` AS `employee_id`,`user`.`ref_shop` AS `ref_shop` from (`employee` join `user` on((`employee`.`employee_id` = `user`.`ref_employee`))) where (not(`employee`.`employee_id` in (select `ancien_employee`.`ref_employee` from `ancien_employee`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-12 14:13:55
