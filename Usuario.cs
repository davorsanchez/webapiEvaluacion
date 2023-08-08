namespace webapi;

public class Usuario
{
    public int COD_USUARIO { get; set; }
    public string TIP_DOCUMENTO { get; set; }
    public string VAR_DOC_IDENTIDAD { get; set; }
    public string VAR_APELLIDOS { get; set; }
    public string VAR_PASSWORD { get; set; }
    public string VAR_NUM_TELEFONO { get; set; }
    public int INT_FLG_ELIMINADO { get; set; }
    public DateTime FEC_REGISTRO { get; set; }
    public DateTime FEC_MODIFICACION { get; set; }

}
