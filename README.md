Buenas! Deje dockerizado en un compose Una DB MYSQL, la API misma y un PHPMyAdmin para apreciar los resultados.

No tuve tiempo de consumir todos los endpoints del Backend como me hubiese gustado.

Si hay problemas con la actualizacion de la DB debe ser por la arquitectura limpia, ejecutar

dotnet ef database update --project Infraestructure --startup-project Web

Gracias!
