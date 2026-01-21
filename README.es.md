# Sistema de Inventarios
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
---

<div style="text-align: right;">
  <a href="README.md">English</a> | <a href="README.es.md">Español</a>
</div>

## Descripción
<p>
  Solución integral desarrollada en C# para la gestión operativa de cadenas comerciales. El sistema centraliza el control de inventarios, movimientos de almacén y procesos de venta, utilizando Microsoft SQL Server para garantizar la integridad de los datos.
  <br><br>
  La arquitectura del proyecto implementa una separación de responsabilidades mediante la librería "ReglasDeNegocio", la cual encapsula toda la lógica de acceso a datos y las políticas del sistema, facilitando el mantenimiento y la escalabilidad.
</p>

## Funcionalidades del proyecto
### **Seguridad**
- **Autenticación interactiva:** Interfaz de inicio de sesión segura para gestionar el acceso de los usuarios al sistema de inventario <br>
  <img width="161" height="361" alt="SisInventory login" src="https://github.com/user-attachments/assets/f318e977-120f-4695-a07c-9239fd9a7e26" />

### **Gestión de Inventarios y Almacenes**
- **Operaciones de Almacén:** Gestión completa de almacenes, lo cual permite el seguimiento organizacional <br>
  <img width="459" height="289" alt="SisInventory warehouse" src="https://github.com/user-attachments/assets/f0ce6039-c683-4e1f-b299-89d97fd7e886" />

- **Catálogo de Productos:** Control centralizado de los datos de los productos, precios de compra y venta <br>
  <img width="460" height="289" alt="SisInventory products" src="https://github.com/user-attachments/assets/645ebf96-583c-4712-a02e-3cc5982eedcb" />

- **Seguimiento del movimiento de inventario:** Registra las entradas y salidas de productos en tiempo real para mantener niveles de inventario precisos en todos los almacenes <br>
  Entrada: <br>
  <img width="459" height="288" alt="SisInventory entry" src="https://github.com/user-attachments/assets/839b738f-c2a1-4b27-a055-73e2cff5d595" />
  <br>
  Salida: <br>
  <img width="460" height="287" alt="SisInventory exit" src="https://github.com/user-attachments/assets/651771c0-1694-487a-a81e-50ca44379794" />

### **Ventas e Informes**
- **Registro de Ventas:** Proceso optimizado para registrar transacciones y actualizar el inventario automáticamente <br>
  <img width="459" height="287" alt="SisInventory sales" src="https://github.com/user-attachments/assets/7d61191e-f3af-4107-be47-cb1582c4b6fe" />

- **Búsqueda y análisis:** Consulta almacenes, productos específicos, saldos actuales y datos históricos de ventas <br>
  <img width="458" height="282" alt="SisInventory search" src="https://github.com/user-attachments/assets/4cbd4206-0893-4909-8431-6cd3f13264da" />
  
## Tecnologías utilizadas
- C#
- Microsoft SQL Server
- Windows Forms App (.NET Framework)
