-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: pruebacsharp
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `pruebacsharp`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `pruebacsharp` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `pruebacsharp`;

--
-- Table structure for table `altitud_optima`
--

DROP TABLE IF EXISTS `altitud_optima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `altitud_optima` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `altitud_optima`
--

LOCK TABLES `altitud_optima` WRITE;
/*!40000 ALTER TABLE `altitud_optima` DISABLE KEYS */;
INSERT INTO `altitud_optima` VALUES (1,'800 - 1200 msnm'),(2,'1200 - 1600 msnm'),(3,'1600 - 2000 msnm'),(4,'500 - 1000 msnm'),(5,'1000 - 1500 msnm'),(6,'1500 - 2000 msnm');
/*!40000 ALTER TABLE `altitud_optima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calidad_grano`
--

DROP TABLE IF EXISTS `calidad_grano`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `calidad_grano` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_calidad_grano_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calidad_grano`
--

LOCK TABLES `calidad_grano` WRITE;
/*!40000 ALTER TABLE `calidad_grano` DISABLE KEYS */;
INSERT INTO `calidad_grano` VALUES (3,'Excelso'),(1,'Extra'),(4,'Premium'),(2,'Supremo');
/*!40000 ALTER TABLE `calidad_grano` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enfermedad`
--

DROP TABLE IF EXISTS `enfermedad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enfermedad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_enfermedad_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enfermedad`
--

LOCK TABLES `enfermedad` WRITE;
/*!40000 ALTER TABLE `enfermedad` DISABLE KEYS */;
INSERT INTO `enfermedad` VALUES (2,'Antracnosis'),(4,'Marchitez vascular'),(3,'Ojo de gallo'),(1,'Roya del café');
/*!40000 ALTER TABLE `enfermedad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maduracion`
--

DROP TABLE IF EXISTS `maduracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `maduracion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_maduracion_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maduracion`
--

LOCK TABLES `maduracion` WRITE;
/*!40000 ALTER TABLE `maduracion` DISABLE KEYS */;
INSERT INTO `maduracion` VALUES (2,'Media'),(3,'Tardía'),(1,'Temprana');
/*!40000 ALTER TABLE `maduracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nombre_cientifico`
--

DROP TABLE IF EXISTS `nombre_cientifico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nombre_cientifico` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_nombre_cientifico_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nombre_cientifico`
--

LOCK TABLES `nombre_cientifico` WRITE;
/*!40000 ALTER TABLE `nombre_cientifico` DISABLE KEYS */;
INSERT INTO `nombre_cientifico` VALUES (1,'Coffea arabica var. Caturra','Variedad de porte bajo, originada por mutación natural de Bourbon en Brasil.'),(2,'Coffea arabica var. Castillo','Variedad desarrollada en Colombia, resistente a la roya.'),(3,'Coffea arabica var. Colombia','Variedad colombiana con alta productividad y buena calidad de taza.'),(4,'Coffea arabica var. Bourbon','Variedad tradicional de alta calidad, originaria de la isla de Bourbon.'),(5,'Coffea sp. (Desconocido)','Temporal: por asignar'),(6,'Coffea arabica',NULL),(7,'Coffea canephora',NULL),(8,'Coffea liberica',NULL);
/*!40000 ALTER TABLE `nombre_cientifico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `origen_linaje`
--

DROP TABLE IF EXISTS `origen_linaje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `origen_linaje` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_origen_linaje_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `origen_linaje`
--

LOCK TABLES `origen_linaje` WRITE;
/*!40000 ALTER TABLE `origen_linaje` DISABLE KEYS */;
INSERT INTO `origen_linaje` VALUES (5,'Arabica'),(2,'Bourbon'),(4,'Caturra'),(1,'Etíope'),(6,'Robusta'),(3,'Typica');
/*!40000 ALTER TABLE `origen_linaje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `porte`
--

DROP TABLE IF EXISTS `porte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `porte` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_porte_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `porte`
--

LOCK TABLES `porte` WRITE;
/*!40000 ALTER TABLE `porte` DISABLE KEYS */;
INSERT INTO `porte` VALUES (3,'Alto'),(1,'Bajo'),(2,'Medio');
/*!40000 ALTER TABLE `porte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `potencial`
--

DROP TABLE IF EXISTS `potencial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `potencial` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_potencial_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `potencial`
--

LOCK TABLES `potencial` WRITE;
/*!40000 ALTER TABLE `potencial` DISABLE KEYS */;
INSERT INTO `potencial` VALUES (1,'Alto rendimiento'),(3,'Bajo rendimiento'),(2,'Medio rendimiento');
/*!40000 ALTER TABLE `potencial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resistencia`
--

DROP TABLE IF EXISTS `resistencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resistencia` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_resistencia_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resistencia`
--

LOCK TABLES `resistencia` WRITE;
/*!40000 ALTER TABLE `resistencia` DISABLE KEYS */;
INSERT INTO `resistencia` VALUES (4,'Alta'),(6,'Baja'),(5,'Media'),(3,'Resistente a Plagas'),(1,'Resistente a Roya'),(2,'Resistente a Sequía');
/*!40000 ALTER TABLE `resistencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resistencia_nivel`
--

DROP TABLE IF EXISTS `resistencia_nivel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resistencia_nivel` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_resistencia_nivel_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resistencia_nivel`
--

LOCK TABLES `resistencia_nivel` WRITE;
/*!40000 ALTER TABLE `resistencia_nivel` DISABLE KEYS */;
INSERT INTO `resistencia_nivel` VALUES (1,'Alta'),(3,'Baja'),(2,'Media');
/*!40000 ALTER TABLE `resistencia_nivel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tamanogranos`
--

DROP TABLE IF EXISTS `tamanogranos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tamanogranos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_tamano_grano_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tamanogranos`
--

LOCK TABLES `tamanogranos` WRITE;
/*!40000 ALTER TABLE `tamanogranos` DISABLE KEYS */;
INSERT INTO `tamanogranos` VALUES (3,'Grande'),(2,'Mediano'),(1,'Pequeño');
/*!40000 ALTER TABLE `tamanogranos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiempo_cosecha`
--

DROP TABLE IF EXISTS `tiempo_cosecha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tiempo_cosecha` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_tiempo_cosecha_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiempo_cosecha`
--

LOCK TABLES `tiempo_cosecha` WRITE;
/*!40000 ALTER TABLE `tiempo_cosecha` DISABLE KEYS */;
INSERT INTO `tiempo_cosecha` VALUES (1,'3 meses'),(2,'4 meses'),(3,'5 meses'),(4,'6 meses');
/*!40000 ALTER TABLE `tiempo_cosecha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `clave` varchar(255) NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  `creado_en` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `actualizado_en` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'eduardo','Africa8220.!',1,'2025-08-16 00:17:16','2025-08-16 00:17:16'),(2,'2','',1,'2025-08-16 00:21:20','2025-08-16 00:21:20'),(3,'Juan','12345678',1,'2025-08-17 20:17:20','2025-08-17 20:17:20'),(4,'alberto','987654321',1,'2025-08-18 03:56:53','2025-08-18 03:56:53');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `variedades`
--

DROP TABLE IF EXISTS `variedades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `variedades` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `tamano_grano_id` int NOT NULL,
  `porte_id` int NOT NULL,
  `enfermedad_id` int NOT NULL,
  `resistencia_nivel_id` int NOT NULL,
  `tiempo_cosecha_id` int NOT NULL,
  `calidad_grano_id` int NOT NULL,
  `potencial_id` int NOT NULL,
  `resistencia_id` int DEFAULT NULL,
  `nombre_cientifico_id` int NOT NULL,
  `altitud_optima_id` int DEFAULT NULL,
  `origen_linaje_id` int DEFAULT NULL,
  `maduracion_id` int DEFAULT NULL,
  `created_by_usuario_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_variedades_nombre` (`nombre`),
  KEY `fk_variedades_tamano_grano` (`tamano_grano_id`),
  KEY `fk_variedades_porte` (`porte_id`),
  KEY `fk_variedades_enfermedad` (`enfermedad_id`),
  KEY `fk_variedades_resistencia_nivel` (`resistencia_nivel_id`),
  KEY `fk_variedades_tiempo_cosecha` (`tiempo_cosecha_id`),
  KEY `fk_variedades_calidad_grano` (`calidad_grano_id`),
  KEY `fk_variedades_potencial` (`potencial_id`),
  KEY `fk_variedades_resistencia` (`resistencia_id`),
  KEY `ix_variedades_nombre_cientifico_id` (`nombre_cientifico_id`),
  KEY `fk_variedades_maduracion` (`maduracion_id`),
  KEY `fk_variedades_origen_linaje` (`origen_linaje_id`),
  KEY `fk_variedades_altitud_optima` (`altitud_optima_id`),
  KEY `fk_variedades_usuario` (`created_by_usuario_id`),
  CONSTRAINT `fk_variedades_altitud_optima` FOREIGN KEY (`altitud_optima_id`) REFERENCES `altitud_optima` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_calidad_grano` FOREIGN KEY (`calidad_grano_id`) REFERENCES `calidad_grano` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_enfermedad` FOREIGN KEY (`enfermedad_id`) REFERENCES `enfermedad` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_maduracion` FOREIGN KEY (`maduracion_id`) REFERENCES `maduracion` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_nombre_cientifico` FOREIGN KEY (`nombre_cientifico_id`) REFERENCES `nombre_cientifico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_origen_linaje` FOREIGN KEY (`origen_linaje_id`) REFERENCES `origen_linaje` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_porte` FOREIGN KEY (`porte_id`) REFERENCES `porte` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_potencial` FOREIGN KEY (`potencial_id`) REFERENCES `potencial` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_resistencia` FOREIGN KEY (`resistencia_id`) REFERENCES `resistencia` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_resistencia_nivel` FOREIGN KEY (`resistencia_nivel_id`) REFERENCES `resistencia_nivel` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_tamano_grano` FOREIGN KEY (`tamano_grano_id`) REFERENCES `tamanogranos` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_tiempo_cosecha` FOREIGN KEY (`tiempo_cosecha_id`) REFERENCES `tiempo_cosecha` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_variedades_usuario` FOREIGN KEY (`created_by_usuario_id`) REFERENCES `usuarios` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `variedades`
--

LOCK TABLES `variedades` WRITE;
/*!40000 ALTER TABLE `variedades` DISABLE KEYS */;
INSERT INTO `variedades` VALUES (5,'Caturra',1,1,1,1,2,2,1,1,1,2,1,2,NULL),(6,'Castillo',2,2,2,2,3,3,2,2,2,3,2,1,NULL),(7,'Colombia',1,3,3,1,1,1,1,3,3,1,3,3,NULL),(8,'Bourbon',3,2,4,3,4,4,3,NULL,4,5,1,2,NULL),(9,'Variedad X',1,1,1,1,1,1,1,2,1,1,2,3,NULL),(10,'Typica',2,3,1,3,3,3,2,6,6,6,3,3,NULL);
/*!40000 ALTER TABLE `variedades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'pruebacsharp'
--

--
-- Dumping routines for database 'pruebacsharp'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-17 23:53:20
