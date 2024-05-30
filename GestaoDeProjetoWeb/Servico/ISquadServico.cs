﻿using GestaoDeProjetoWeb.Data.Squad;
using GestaoDeProjetoWeb.Data.Util;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ISquadServico
    {

        Task<List<SquadDto>> ObterTodasSquadAsync();
        Task<List<ComboItem>> ObterComboAsync();
    }
}
