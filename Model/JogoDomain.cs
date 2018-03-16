using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaSena.Model
{
    public class JogoDomain
    {
        [Required(ErrorMessage="Campo de quantidade de jogos obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Digitar um número inteiro válido.")]
        public int QuantidadeJogos { get; set; }

        [Required(ErrorMessage="Campo de quantidade de números por jogo obrigatório!")]
        [Range(6, 15, ErrorMessage = "Só é possível gerar jogos de 6 a 15 números. Informe um valor nesse intervalo.")]
        public int QuantidadeNumeros { get; set; }

        public List<String> Jogos { get; set; }
    }
}