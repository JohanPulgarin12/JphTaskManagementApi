using JphTaskManagementApi.Domain.Models.Farma.SP;
using JphTaskManagementApi.Domain.Models.Farma.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories.Interfaces
{
    public interface IGenericoRepository
    {
        #region POST
        bool PostUsuarioAdministrativo(UsuarioAdministrativoPost usuario);
        #endregion

        #region GET
        List<UsuarioAdministrativo> GetUsuarioAdministrativo();
        #endregion

        #region UPDATE
        bool UpdateUsuarioAdministrativo(UsuarioAdministrativoUpdate usuario);
        #endregion

        #region DELETE
        bool DeleteUsuarioAdministrativo(int idUsuario);
        #endregion
    }
}
