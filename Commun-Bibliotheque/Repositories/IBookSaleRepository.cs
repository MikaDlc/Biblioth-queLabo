﻿using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public  interface IBookSaleRepository<TBookSale> where TBookSale : IBookSale
    {
        public void Insert(TBookSale entity);
        public void SaleTheBook(int BookID, int LibraryID);
        public void Delete(int BookID, int SaleID);
    }
}
