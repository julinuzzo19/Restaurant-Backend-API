# Restaurant-Backend-API
El representante comercial de un importante restaurante ubicado en GBA sur lo contrata
para realizar el desarrollo de un menú digital, el representante le comenta que como está la
situación actual los restaurantes tuvieron que aplicar medidas para poder mantenerse
abiertos y una de estas fue dejar de compartir la carta con los clientes. Por lo tanto necesita
de una aplicación web que visualice la información que contenía la vieja carta, además se
debe poder tomar la comanda de un cliente para su preparación
La entrega de esta app se realiza en tres etapas:
1. Entrega de prototipo con lógica de base de datos (TP 1)
2. Entrega de Backend con la lógica de negocios (TP 2)
3. Entrega de Página web (TP 3)
Por lo tanto, Los criterios de aceptación son:
1. Debe permitir registrar la mercadería (platos, bebida o postre).
2. Debe permitir registrar las comandas (el pedido del cliente)
3. Debe enlistar las comandas con el detalle de los platos según la fecha que se le
ingrese.
4. Debe enlistar la información de la mercadería y permitir filtrar por tipo de mercadería
5. Debe permitir modificar la información de la mercadería.
6. Debe permitir eliminar la mercadería.
7. Agregar búsqueda de mercadería por id.
8. Agregar búsqueda de comanda por id.
Consigna:
Realizar una aplicación con la arquitectura API Rest, que exponga los servicios necesarios
para cumplir con los criterios de aceptación.
Se deberá reescribir la aplicación de consola realizada en el TP 1 y adaptarla a los nuevos
requerimientos.
● La aplicación se debe ajustar al standard de REST. Tanto los métodos de petición
como los de respuesta.
● Las URL de los endpoint deben ser las que se detallan en este documento.
● Los datos que se devuelven deben estar en formato JSON
● Se debe incluir la librería Swagger o OpenApi (ver =>
https://dev.to/burdier/guia-swagger-en-asp-net-core-para-un-amigo-o4i o
Cátedra: Proyecto de Software
Docente: Ing. Olivera Lucas
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuck
le?view=aspnetcore-5.0&tabs=visual-studio)
EndPoints:
1. [*] >/api/mercaderia
BODY
{
“nombre” : ”milanesa”,
“tipo” : 1,
“precio” : 200,
“ingredientes”: “sal y pimienta”,
“preparacion”: “prendes el fuego..”,
“imagen”: url_imagen
}
2. [*] >/api/comanda
BODY
{
“mercaderia”: [(array de ids)],
“formaEntrega”: 1
}
3. [*] >/api/comanda
a. QueryParams { fecha = “fecha de hoy” }
4. [GET] >/api/mercaderia
QueryParams
{ tipo = (1, 2,...) }
5. [*] >/api/mercaderia
BODY
{
“nombre” : ”milanesa”,
“tipo” : 1,
“precio” : 200,
“ingredientes”: “sal y pimienta”,
“preparacion”: “prendes el fuego..”,
“imagen”: url_imagen
}
6. [*] >/api/mercaderia/{id}
7. [GET] >/api/mercaderia/{id}
8. [GET] >/api/comanda/{id}
Aclaración:
● Las url, parámetros y body definidos previamente deben respetarse.
● [*] : el método HTTP a utilizar en este endpoint debe ser seleccionado por el
estudiante según el estándar REST
