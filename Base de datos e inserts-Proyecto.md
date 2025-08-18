```sql
CREATE DATABASE IF NOT EXISTS `pruebacsharp` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `pruebacsharp`;

CREATE TABLE `altitud_optima` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `calidad_grano` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_calidad_grano_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `enfermedad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_enfermedad_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `maduracion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_maduracion_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nombre_cientifico` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_nombre_cientifico_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `origen_linaje` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_origen_linaje_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `porte` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_porte_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `potencial` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_potencial_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `resistencia` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_resistencia_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `resistencia_nivel` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_resistencia_nivel_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tamanogranos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_tamano_grano_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tiempo_cosecha` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_tiempo_cosecha_nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `clave` varchar(255) NOT NULL,
  `rol` varchar(50) NOT NULL DEFAULT 'operador',
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  `creado_en` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `actualizado_en` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `variedades` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(120) NOT NULL,
  `usuario_id` int DEFAULT NULL,
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
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_variedades_nombre` (`nombre`),
  KEY `fk_variedades_usuario` (`usuario_id`),
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
  CONSTRAINT `fk_variedades_usuario` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
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
  CONSTRAINT `fk_variedades_altitud_optima` FOREIGN KEY (`altitud_optima_id`) REFERENCES `altitud_optima` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


```

```sql
INSERT INTO `altitud_optima` (`id`,`nombre`) VALUES
(1,'800 - 1200 msnm'),
(2,'1200 - 1600 msnm'),
(3,'1600 - 2000 msnm'),
(4,'500 - 1000 msnm'),
(5,'1000 - 1500 msnm'),
(6,'1500 - 2000 msnm');

INSERT INTO `calidad_grano` (`id`,`nombre`) VALUES
(3,'Excelso'),
(1,'Extra'),
(4,'Premium'),
(2,'Supremo');

INSERT INTO `enfermedad` (`id`,`nombre`) VALUES
(2,'Antracnosis'),
(4,'Marchitez vascular'),
(3,'Ojo de gallo'),
(1,'Roya del café');

INSERT INTO `maduracion` (`id`,`nombre`) VALUES
(2,'Media'),
(3,'Tardía'),
(1,'Temprana');

INSERT INTO `nombre_cientifico` (`id`,`nombre`,`descripcion`) VALUES
(1,'Coffea arabica var. Caturra','Variedad de porte bajo, originada por mutación natural de Bourbon en Brasil.'),
(2,'Coffea arabica var. Castillo','Variedad desarrollada en Colombia, resistente a la roya.'),
(3,'Coffea arabica var. Colombia','Variedad colombiana con alta productividad y buena calidad de taza.'),
(4,'Coffea arabica var. Bourbon','Variedad tradicional de alta calidad, originaria de la isla de Bourbon.'),
(5,'Coffea sp. (Desconocido)','Temporal: por asignar'),
(6,'Coffea arabica',NULL),
(7,'Coffea canephora',NULL),
(8,'Coffea liberica',NULL);

INSERT INTO `origen_linaje` (`id`,`nombre`) VALUES
(5,'Arabica'),
(2,'Bourbon'),
(4,'Caturra'),
(1,'Etíope'),
(6,'Robusta'),
(3,'Typica');

INSERT INTO `porte` (`id`,`nombre`) VALUES
(3,'Alto'),
(1,'Bajo'),
(2,'Medio');

INSERT INTO `potencial` (`id`,`nombre`) VALUES
(1,'Alto rendimiento'),
(3,'Bajo rendimiento'),
(2,'Medio rendimiento');

INSERT INTO `resistencia` (`id`,`nombre`) VALUES
(4,'Alta'),
(6,'Baja'),
(5,'Media'),
(3,'Resistente a Plagas'),
(1,'Resistente a Roya'),
(2,'Resistente a Sequía');

INSERT INTO `resistencia_nivel` (`id`,`nombre`) VALUES
(1,'Alta'),
(3,'Baja'),
(2,'Media');

INSERT INTO `tamanogranos` (`id`,`nombre`) VALUES
(3,'Grande'),
(2,'Mediano'),
(1,'Pequeño');

INSERT INTO `tiempo_cosecha` (`id`,`nombre`) VALUES
(1,'3 meses'),
(2,'4 meses'),
(3,'5 meses'),
(4,'6 meses');

INSERT INTO `usuarios` (`id`,`nombre`,`clave`,`activo`,`creado_en`,`actualizado_en`) VALUES
(1,'eduardo','Africa8220.!',1,'2025-08-16 00:17:16','2025-08-16 00:17:16');

INSERT INTO `variedades` (`id`,`nombre`,`usuario_id`,`tamano_grano_id`,`porte_id`,`enfermedad_id`,`resistencia_nivel_id`,`tiempo_cosecha_id`,`calidad_grano_id`,`potencial_id`,`resistencia_id`,`nombre_cientifico_id`,`altitud_optima_id`,`origen_linaje_id`,`maduracion_id`) VALUES
(5,'Caturra',1,1,1,1,1,2,2,1,1,1,2,1,2),
(6,'Castillo',1,2,2,2,2,3,3,2,2,2,3,2,1),
(7,'Colombia',1,1,3,3,1,1,1,1,3,3,1,3,3),
(8,'Bourbon',1,3,2,4,3,4,4,3,NULL,4,5,1,2),
(9,'Variedad X',1,1,1,1,1,1,1,1,2,1,1,2,3);
```

