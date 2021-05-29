using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace AccessData
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            builder.Entity<FormaEntrega>().HasData(
            new FormaEntrega
            {
                FormaEntregaId = 1,
                Descripcion = "Salon"
            },
            new FormaEntrega
            {
                FormaEntregaId = 2,
                Descripcion = "Delivery"
            },
            new FormaEntrega
            {
                FormaEntregaId = 3,
                Descripcion = "Pedidos Ya"
            });

            builder.Entity<TipoMercaderia>().HasData(
                new TipoMercaderia { TipoMercaderiaId = 1, Descripcion = "Entrada" },
                new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" },
                new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" },
                new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" },
                new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" },
                new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" },
                new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensalada" },
                new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" },
                new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cerveza Artesanal" },
                new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" }
                );

            builder.Entity<Mercaderia>().HasData(
                 new Mercaderia { MercaderiaId = 1, Nombre = "Jamon", Precio = 150, Ingredientes = "Fetas de jamon", Preparacion = "Cortar fetas de jamon", Imagen = "https://s1.eestatic.com/2021/01/22/ciencia/nutricion/553206479_171070440_1024x576.jpg", TipoMercaderiaId = 1 },
                new Mercaderia { MercaderiaId = 2, Nombre = "Queso", Precio = 130, Ingredientes = "Queso comun, azul y roquefort", Preparacion = "Picada con los distintos tipos de queso", Imagen = "https://lacteoselpuente.com.ar/assets/img/picadita/picada_queso_premium.png", TipoMercaderiaId = 1 },
                new Mercaderia { MercaderiaId = 3, Nombre = "Pizza con aceitunas negras", Precio = 350, Ingredientes = "Harina, queso, salsa y aceitunas negras", Preparacion = "Hornear pizza y agregar aceitunas", Imagen = "https://okdiario.com/img/2019/01/17/pizza-de-atun-con-aceitunas-negras-655x368.jpg", TipoMercaderiaId = 5 },
                new Mercaderia { MercaderiaId = 4, Nombre = "Ravioles de ricota", Precio = 400, Ingredientes = "Ravioles de ricota, salsa fileto y albahaca", Preparacion = "Hervir ravioles y colocar salsa", Imagen = "https://unaricareceta.com/wp-content/uploads/2020/01/Webp.net-resizeimage-95.jpg", TipoMercaderiaId = 3 },
                new Mercaderia { MercaderiaId = 5, Nombre = "Asado a la parrilla", Precio = 480, Ingredientes = "Carne y sal", Preparacion = "Asar la carne", Imagen = "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2018/08/09173312/asado.jpg", TipoMercaderiaId = 4 },
                new Mercaderia { MercaderiaId = 6, Nombre = "Cerveza artesanal", Precio = 200, Ingredientes = "Cerveza artesanal", Preparacion = "Cerveza estacionada", Imagen = "https://infoagro.com.ar/wp-content/uploads/2020/04/cerveza-artesanal-en-crisis-3.jpg", TipoMercaderiaId = 9 },
                new Mercaderia { MercaderiaId = 7, Nombre = "Ensalada Waldorf", Precio = 150, Ingredientes = "Lechuga, nueces, hinojo y hongos", Preparacion = "Cortar ingredientes y mezclar en una fuente", Imagen = "https://s1.eestatic.com/2021/01/22/ciencia/nutricion/553206479_171070440_1024x576.jpg", TipoMercaderiaId = 7 },
                new Mercaderia { MercaderiaId = 8, Nombre = "Postre helado", Precio = 280, Ingredientes = "Bochas de helado de chocolate, americana, crema y cereza", Preparacion = "Colocar bochas de helado con crema y luego la cereza", Imagen = "http://resizer.sevilla.abc.es/resizer/resizer.php?imagen=https://sevilla.abc.es/gurme//wp-content/uploads/sites/24/2012/06/postres-helados.jpg&nuevoancho=1920", TipoMercaderiaId = 10 }

               );
        }
    }
}