namespace PortalUsuario.Shared.DTO;

public class RatDto
{
    public int IDRAT { get; set; }
    public int NSEQ { get; set; }
    public string STATUS { get; set; }
    public string USUARIOS { get; set; }
    public string CODUSUARIO { get; set; }
    public string USUARIOALTERACAO { get; set; }
    public DateTime? DATA { get; set; }
    public DateTime? DATAULTIMAALTERACAO { get; set; }
    public DateTime? DATAINICIAL { get; set; }
    public DateTime? DATAFIM { get; set; }
    public string HMCHEGADA { get; set; }
    public string HMSAIDA { get; set; }
    public string HTCHEGADA { get; set; }
    public string HTSAIDA { get; set; }
    public decimal TOTAL { get; set; }
    public decimal KM { get; set; }
    public string TIPO { get; set; }
    public short TIPOAGENDA { get; set; }
    public decimal VALORESTACIONAMENTO { get; set; }
    public decimal VALORJANTA { get; set; }
    public decimal VALORALMOCO { get; set; }
    public decimal VALORPEDAGIO { get; set; }
    public decimal VALORHOTEL { get; set; }
    public decimal REFEICAO { get; set; }
    public string CODTDO { get; set; }
    public int CODCOLIGADA { get; set; }
    public string CODCFO { get; set; }
    public int CODCOLCFO { get; set; }
    public int CODCOLCFOVISUALIZACAO { get; set; }
    public string CLIENTE { get; set; }
    public string CODCONTRATO { get; set; }
    public string PLACA { get; set; }
    public string ATENDIMENTO { get; set; }
    public int TIPOOPERACAO { get; set; }
    public string OBSERVACAO { get; set; }
    public string CONTRATO { get; set; }
    public int GeraRAT { get; set; }
    public int HomeOffice { get; set; }
    public int IDFATURAMENTORC { get; set; }

    public IEnumerable<RatItensDto> Itens { get; set; }
}