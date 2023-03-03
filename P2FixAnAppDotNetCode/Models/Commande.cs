using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    public class Commande
    {
        [JsonIgnore]
        public int IdCommande { get; set; }
        [JsonIgnore]
        public ICollection<LignePanier> Lignes { get; set; }

        [Required(ErrorMessage = "ErrorMissingName")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "ErrorMissingAddress")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "ErrorMissingCity")]
        public string Ville { get; set; }

        
        [RegularExpression(@"(\b[A-Z]{2}\d[A-Z]{2}\b|\b\d{5}\b)", ErrorMessage = "Le code postal doit être au format AA1A 1AA pour l'Angleterre ou un nombre de 5 chiffres pour l'Espagne.")]
        public string? CodePostal { get; set; }

        [Required(ErrorMessage = "ErrorMissingCountry")]
        public string Pays { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }
        public Commande() 
        { 
         Date= DateTime.Now;
        } 
    }
}
