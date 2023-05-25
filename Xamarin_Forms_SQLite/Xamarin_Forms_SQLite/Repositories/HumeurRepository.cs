using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin_Forms_SQLite.Models;

namespace Xamarin_Forms_SQLite.Repositories
{
    public class HumeurRepository
    {
        protected SQLiteAsyncConnection _connection;
        private int nbHumeurs { get; set; }
        private string Message { get; set; }
        private string monHumeur { get; set; }

        public HumeurRepository(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Humeur>();
        }

        public async Task AjouterHumeurAsync(string commentaire, int note, DateTime dateAjout)
        {
            try
            {
                nbHumeurs = await _connection.InsertAsync(new Humeur { Commentaire = commentaire, Note = note, DateAjout = dateAjout });
                // Gestion d'un message à afficher
                string message = $"Humeur du jour ajoutée : {commentaire}.\n {note}.\n {dateAjout}";
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                string message = $"Impossible d'ajouter l'humeur : {commentaire}.\n Erreur : {e.Message}";
                Console.WriteLine(message);
            }
        }

        public async Task<List<Humeur>> ListeHumeursAsync()
        {
            try
            {
                return await _connection.Table<Humeur>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération de la liste des humeurs : " + ex.Message);
                return new List<Humeur>(); // Retournez une liste vide ou null en cas d'erreur
            }
        }
        public async Task SupprimerAllHumeurs<T>()
        {
            await _connection.DeleteAllAsync<Humeur>();
        }
        public async Task SupprimerUneHumeur(Humeur humeur)
        {
            await _connection.DeleteAsync(humeur);
        }
    }
}