using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{

    //elimizdeki nesnelerin veri tabanı ile olan konfigurasyonunu yapıyoruz.
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(b => b.Id); //veri tabanındaki Categories tablosuna bağla   HasKey(b => b.Id) = primarykey i Id dir
            builder.Property(b => b.Id).HasColumnName("CategoryId").IsRequired(); //Id diye bir kolonu vardır bu veritabanında CategoryId denk gelir
            builder.Property(b => b.Name).HasColumnName("CategoryName").IsRequired();
            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_Name").IsUnique(); //Name alanına unique key (bir data bir daha tekrarlanamaz) bırak (PK dışında tekrarlanamaz istediğimiz)
            builder.HasMany(b => b.Products); //Category bir sürü ürünü var
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);    // bütün sorgularıma default olarak bu koşulu uygula.
            //soft delete => veri silinmiyor onun yerine deletedDate veriyoruz (silindi anlamına geliyor)
            //eğer bir datanın DeletedDate yoksa veriyi getir
            //silinen kayıtları select koşullarıma default olarak uygulama
            //where deleteddate = null olanları getir

        }
    }


}


