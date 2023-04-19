using System.Collections;

namespace PortalUsuario.Shared.Models;

public class RatItensModel
{
   
        public int CodColigada { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Horas { get; set; }
        public string Modulo { get; set; }
        public int Servico { get; set; }
        public string Tipo { get; set; }
        public string GetTipo { get; set; }
        public string Descricao { get; set; }
        public int Id_RefRat { get; set; }
        public DateTime? Data { get; set; }
        public string NomeSistema { get; set; }
        public string Operacao { get; set; }
    
    
}