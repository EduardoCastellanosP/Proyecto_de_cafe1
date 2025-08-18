









```sql
CREATE TABLE nombre_cientifico (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(120) NOT NULL,
    descripcion VARCHAR(500) DEFAULT NULL,
    UNIQUE KEY uq_nombre_cientifico_nombre (nombre)
) ENGINE=InnoDB;
CREATE TABLE origen_linaje (
    id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY uq_origen_linaje_nombre (nombre)
);


CREATE TABLE IF NOT EXISTS maduracion (
  id INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(100) NOT NULL,
  CONSTRAINT pk_maduracion PRIMARY KEY (id),
  CONSTRAINT uq_maduracion_nombre UNIQUE (nombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE altitud_optima (
    id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY uq_altitud_optima_nombre (nombre)
);

```

```sql
INSERT INTO nombre_cientifico (nombre, descripcion) VALUES
('Coffea arabica var. Caturra', 'Variedad de porte bajo, originada por mutación natural de Bourbon en Brasil.'),
('Coffea arabica var. Castillo', 'Variedad desarrollada en Colombia, resistente a la roya.'),
('Coffea arabica var. Colombia', 'Variedad colombiana con alta productividad y buena calidad de taza.'),
('Coffea arabica var. Bourbon', 'Variedad tradicional de alta calidad, originaria de la isla de Bourbon.');

-- Origen Linaje
INSERT INTO origen_linaje (nombre) VALUES
('Etíope'),
('Bourbon'),
('Typica'),
('Caturra');

-- Maduración
INSERT INTO maduracion (nombre) VALUES
('Temprana'),
('Media'),
('Tardía');

-- Altitud Óptima
INSERT INTO altitud_optima (nombre) VALUES
('800 - 1200 msnm'),
('1200 - 1600 msnm'),
('1600 - 2000 msnm');

INSERT INTO resistencia (nombre) VALUES ('Alta'), ('Media'), ('Baja');
INSERT INTO altitud_optima (nombre) VALUES ('500-1000 msnm'), ('1000-1500 msnm'), ('1500-2000 msnm');
INSERT INTO maduracion (nombre) VALUES ('Temprana'), ('Media'), ('Tardía');
INSERT INTO origen_linaje (nombre) VALUES ('Arabica'), ('Robusta');

-- Ejemplos (ajusta los IDs según existan en tus catálogos)
UPDATE variedades SET origen_linaje_id = 1, maduracion_id = 2 WHERE id = 5; -- Caturra
UPDATE variedades SET origen_linaje_id = 2, maduracion_id = 1 WHERE id = 6; -- Castillo
UPDATE variedades SET origen_linaje_id = 3, maduracion_id = 3 WHERE id = 7; -- Colombia
UPDATE variedades SET origen_linaje_id = 1, maduracion_id = 2 WHERE id = 8; -- Bourbon

-- Ejemplos: ajusta los IDs según corresponda
UPDATE variedades SET altitud_optima_id = 2 WHERE id = 5; -- Caturra
UPDATE variedades SET altitud_optima_id = 3 WHERE id = 6; -- Castillo
UPDATE variedades SET altitud_optima_id = 1 WHERE id = 7; -- Colombia
UPDATE variedades SET altitud_optima_id = 5 WHERE id = 8; -- Bourbon


```

