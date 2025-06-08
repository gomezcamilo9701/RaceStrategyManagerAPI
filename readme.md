RaceStrategyManager Parte 1

Esta es una API hecha con .NET 8 para gestionar al Tech Racing F1.

Requisitos

.NET 8 SDK instalado.
Una base de datos SQL Server.

Configuración Inicial

cd RaceStrategyManagerAPI

Restaura las dependencias:Ejecuta este comando en la carpeta del proyecto para instalar los paquetes NuGet:
dotnet restore


Configura la base de datos:

Abre el archivo appsettings.json en la raíz del proyecto.
¡IMPORTANTE! Cambia el ConnectionString para que apunte a tu base de datos. Por defecto, está configurado así:"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RaceStrategyManager;Trusted_Connection=True;TrustServerCertificate=true;Integrated Security=true;"
}


Reemplaza Server=localhost por el nombre de tu servidor SQL (por ejemplo, Server=mi-servidor).
Asegúrate de que el nombre de la base de datos (Database=RaceStrategyManager) exista en tu servidor, o cámbialo si usas otro nombre.
Si usas autenticación de SQL Server en lugar de Trusted_Connection, actualiza el ConnectionString con tu usuario y contraseña, por ejemplo:"Server=mi-servidor;Database=RaceStrategyManager;User Id=mi-usuario;Password=mi-contraseña;TrustServerCertificate=true;"