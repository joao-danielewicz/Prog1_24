namespace ProjetoLocadora.Models{
    public enum TiposMidia : byte {
        None = 0b_0000_0000,
        Filme = 0b_0000_0001,
        Serie = 0b_0000_0010,
        Documentario = 0b_0000_0011,
        Novela = 0b_0000_0100
    }
}