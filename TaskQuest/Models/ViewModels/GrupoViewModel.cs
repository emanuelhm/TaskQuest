﻿using System.Collections.Generic;
using TaskQuest.Models;

namespace TaskQuest.ViewModels
{
    public class GrupoViewModel
    {

        public Grupo Grupo = new Grupo();

        public List<User> Integrantes = new List<User>();

        public List<Quest> Quests = new List<Quest>();

        public AdicionarIntegranteViewModel AdicionarIntegranteViewModel(int Id){
            var aux = new AdicionarIntegranteViewModel()
            {
                gru_id = this.Grupo.Id
            };
            return aux;
        }

    }
}