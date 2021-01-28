# SINERGIA.TEST
TEST

v0.1
Descripción de proyecto:
- API.TEST (API)
- TEST (FRONT)
- Common (Libreria de clases compartidas del proyecto)
- MainData (Libreria de clases para modelos de base de datos)

Para correr el proyecto seleccionar:
- API.TEST
- TEST (FRONT)

Restaurar base de datos (Dentro de proyecto MainData)

Cambiar el string de conexión
- MainData
  - SINERGIAContext.cs
  
  <code>
    optionsBuilder.UseSqlServer("Server=RAIDEN-OF-STEAL;Database=SINERGIA;Trusted_Connection=True;");
  </code>
  
