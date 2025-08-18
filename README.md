☕ Colombian Coffee — Console App (C# / .NET 9)

Explora, filtra y genera fichas técnicas en PDF de variedades de café cultivadas en Colombia, usando EF Core + MySQL.

<p align="left"> <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" /> <img src="https://img.shields.io/badge/EF%20Core-9.0-512BD4" /> <img src="https://img.shields.io/badge/MySQL-8.x-4479A1?logo=mysql&logoColor=white" /> <img src="https://img.shields.io/badge/License-MIT-green" /> </p>

🧭 Tabla de contenido

* Descripción
* Características
* Arquitectura
* Requisitos
* Instalación
* Configuración
* Ejecución
* Estructura del proyecto
* Imágenes y PDFs
* Solución de problemas
____________________________________________________________________________________________________

📖 Descripción

Colombian Coffee es una aplicación de consola en C# (.NET 9) que permite:

- Consultar y filtrar variedades de café por atributos agronómicos.

- Generar PDFs con la ficha técnica (incluyendo imagen) de una o varias variedades.

- Gestionar contenidos mediante un flujo básico de usuarios/login.

- Se aplican principios SOLID, Arquitectura Hexagonal (Ports & Adapters) y Vertical Slicing. Módulos: Usuarios/Login, Variedades, PDF, Admin, Shared.

  _________________________________________________________________________________________________

  ✨ Características

Usuarios: inicio de sesión y validaciones básicas.

Variedades:

Nombre común y científico

Imagen de referencia

Porte, tamaño de grano, altitud óptima

Potencial y calidad de grano

Resistencias (roya, etc.)

Info agronómica: tiempo de cosecha, maduración

Filtros dinámicos por cualquier atributo (combinables).

PDFs individuales o en lote (incluye imagen si existe).

_________________________________________________________________________________________________________

🧱 Arquitectura

Vertical Slice Architecture (caso de uso por módulo).

Hexagonal (Ports & Adapters).

Patrones usados: Repository, Service, Factory, Singleton.

___________________________________________________________________________________________________________

✅ Requisitos

.NET SDK 9.0

MySQL 8.x

___________________________________________________________________________________________________________

📦 Instalación

Clona el repo e instala paquetes:

git clone <URL-del-repo>
cd <carpeta-del-repo>

dotnet restore
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.8
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-rc.1.efcore.9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.8
dotnet add package Microsoft.Extensions.Configuration --version 9.0.8
dotnet add package Microsoft.Extensions.Configuration.Json --version 9.0.8
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables --version 9.0.8
dotnet add package MySql.Data --version 9.4.0
dotnet add package iTextSharp --version 5.5.13.4

Nota: iTextSharp 5.x es de .NET Framework y puede mostrar NU1701. Funciona, pero si quieres evitar esa alerta considera iTextSharp.LGPLv2.Core o QuestPDF (requerirá adaptar código).

_______________________________________________________________________________________________________________________

⚙️ Configuración

Crea appsettings.json en la raíz del proyecto (junto al .csproj):

{
  "ConnectionStrings": {
    "Default": "server=localhost;port=3306;database=pruebacsharp;user=root;password=TU_PASSWORD;TreatTinyAsBoolean=true;SslMode=None;"
  }
}

_____________________________________________________________________________________________________________________________

🗂️ Estructura del proyecto (simplificada)

src/
 ├─ Modules/
 │   ├─ Usuarios/
 │   ├─ Variedades/
 │   ├─ Pdf/
 │   │   └─ Resources/   # Generadores PDF por variedad
 │   └─ Admin/
 └─ Shared/
Imagenes/                # 📷 PNG/JPG de variedades (al lado del .csproj)
appsettings.json
proyectoC#.csproj

________________________________________________________________________________________________________________________________

🖼️ Imágenes y PDFs

Coloca las imágenes en la carpeta ./Imagenes (junto al .csproj).

Nombre del archivo = nombre de la variedad en minúsculas.
Ejemplos: typica.png, bourbon.png, caturra.png, colombia.png, castillo.png.

Los PDFs se generan en la carpeta donde ejecutes la app (o según la ruta que definas en tus generadores).

_____________________________________________________________________________________________________________________________________

🧩 Solución de problemas

NU1701 con iTextSharp
Es normal (paquete .NET Framework). Si te molesta la advertencia:

Cambia a iTextSharp.LGPLv2.Core o

Migra a QuestPDF (layout moderno, requiere cambiar código).

La imagen no sale en el PDF

Verifica que exista en ./Imagenes.

El nombre debe coincidir (minúsculas): variedad.png.

Asegúrate de que el código busque en Path.Combine("Imagenes", $"{nombre}.png").

AsNoTracking o métodos async no se encuentran

Falta using Microsoft.EntityFrameworkCore; en el archivo.

Confirma versión de EF Core (9.0.x).

__________________________________________________________________________________________________________________________________________

📄 Licencia

Este proyecto está bajo licencia MIT. Consulta el archivo LICENSE si aplica.

___________________________________________________________________________________________________________________________________________

## 👥 Integrantes y Roles

| Integrante | Rol | Responsabilidades Clave |
|-----------|-----|-------------------------|
| *Eduardo* | *Líder del grupo* | Delegación de funciones, *ficha técnica* de variedades |
| *Juliana* | *Login & Usuarios* | Autenticación, gestión/validación de usuarios |
| *Ivanna* | Filtros | Diseño e implementación de *filtros dinámicos y combinables* |
| *Jhinet* | PDF | *Generación y diseño de PDFs* (catálogo y fichas) |
