using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2.Fluent_API_Data_Annotations_migration;

/*
    * Завдання 1
    * Відкрити рішення завданя 2 (1 урок)
    * Потрібно:
    * Обмежити всі строкові властивості (обмеження підбирати, виходячи з призначення поля) через DataAnnotations.
    * Змінити назву Id на – (НазваКласу)Id.
    * Для полів з типом DateTime вказати тип Date через DataAnnotations Внести всі зміни у базу.

 */
public partial class Product
{
    //[Column("Product_id")]
    public int Id { get; set; }

    //[MaxLength(50)]
    public string? Name { get; set; }

    //[Column(TypeName = "money")]
    public decimal Cost { get; set; }
    
    //[MaxLength(500)]
    public string? Description { get; set; }

    public int Quantity { get; set; }

    //[Column(TypeName = "date")]
    public DateTime? ManufactureDate { get; set; }

    public int AlterId { get; set; }
}
