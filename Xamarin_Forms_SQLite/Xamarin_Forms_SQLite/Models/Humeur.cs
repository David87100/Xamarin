using System;
using SQLite;

namespace Xamarin_Forms_SQLite.Models
{
    [Table("Humeur")]
    public class Humeur
    {
        // Clé primaire ID
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        // Commentaire 
        [MaxLength(50)]
        public string Commentaire { get; set; }
        
        // Note correspond à 1 si “Bonne humeur” et 0 si “Mauvaise humeur”
        public int Note { get; set; }
        
        // Date d'ajout
        public DateTime DateAjout { get; set; }
        
    }
}