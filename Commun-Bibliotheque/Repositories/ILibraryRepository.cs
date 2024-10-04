﻿using Commun_Bibliotheque.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Commun_Bibliotheque.Repositories
{
    public interface ILibraryRepository<TLibrary> where TLibrary : ILibrary
    {
        public IEnumerable<TLibrary> Get();
        public TLibrary Get(int id);
        public int Insert(TLibrary entity);
        public void Update(int id, TLibrary entity);
    }
}
