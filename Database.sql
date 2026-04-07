CREATE DATABASE  IF NOT EXISTS `fitness_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `fitness_db`;
-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fitness_db
-- ------------------------------------------------------
-- Server version	8.0.44

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `activities`
--

DROP TABLE IF EXISTS `activities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `activities` (
  `activity_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `activity_type` varchar(50) NOT NULL,
  `metric1` float NOT NULL,
  `metric2` float NOT NULL,
  `metric3` float NOT NULL,
  `duration_hours` float NOT NULL,
  `weight_kg` float NOT NULL,
  `calories` float NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`activity_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activities`
--

LOCK TABLES `activities` WRITE;
/*!40000 ALTER TABLE `activities` DISABLE KEYS */;
INSERT INTO `activities` VALUES (1,1,'Cycling',1,12,5,0.2,150,210,'2026-04-05 07:56:00'),(2,1,'Jump Rope',25,1,25,0.0166667,160,32,'2026-04-05 07:56:00'),(3,5,'Cycling',120,60,120,1,165,165,'2026-04-05 07:56:00'),(4,5,'Cycling',120,60,120,1,165,165,'2026-04-05 07:56:00'),(5,5,'Jump Rope',120,20,6,0.333333,165,55,'2026-04-05 07:56:00'),(6,1,'Cycling',120,12,10,0.2,164,32.8,'2026-04-04 12:09:49'),(7,1,'Walking',120,45,12,0.75,164,123,'2026-04-05 12:11:57'),(8,1,'Walking',51,26,32,0.433333,165,71.5,'2026-04-05 15:48:22'),(9,6,'Walking',12,1,12,0.0166667,120,2,'2026-04-05 17:14:05');
/*!40000 ALTER TABLE `activities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `goals`
--

DROP TABLE IF EXISTS `goals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `goals` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `goal_calories` int NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'ongoing',
  `updated_day` date DEFAULT (curdate()),
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `goals_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goals`
--

LOCK TABLES `goals` WRITE;
/*!40000 ALTER TABLE `goals` DISABLE KEYS */;
INSERT INTO `goals` VALUES (1,1,500,'completed',NULL),(2,5,200,'completed',NULL),(3,5,200,'ongoing',NULL),(4,1,200,'completed','2026-04-05'),(5,1,500,'completed','2026-04-05'),(6,1,500,'completed','2026-04-05'),(7,1,200,'completed','2026-04-05'),(8,1,200,'completed','2026-04-05'),(9,1,200,'completed','2026-04-05'),(10,1,200,'completed','2026-04-05'),(11,1,200,'completed','2026-04-05'),(12,1,200,'completed','2026-04-05'),(13,1,200,'completed','2026-04-05'),(14,1,500,'completed','2026-04-05'),(15,1,500,'completed','2026-04-05'),(16,1,500,'completed','2026-04-05'),(17,1,500,'completed','2026-04-05'),(18,1,300,'completed','2026-04-05'),(19,1,300,'completed','2026-04-05'),(20,1,300,'completed','2026-04-05'),(21,1,300,'completed','2026-04-05'),(22,1,400,'completed','2026-04-05'),(23,1,400,'completed','2026-04-05'),(24,1,400,'completed','2026-04-05'),(25,1,400,'completed','2026-04-05'),(26,1,400,'completed','2026-04-05'),(27,1,400,'completed','2026-04-05'),(28,1,500,'ongoing','2026-04-05');
/*!40000 ALTER TABLE `goals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `CustomerName` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Bobo','B123456789bq'),(2,'lewis','123456789qwE'),(3,'Seni','Seni12345678'),(4,'Nobel','Nobel1234567'),(5,'Delat','Delat9876543'),(6,'Bo1','B123456789bq');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-06  0:03:11
