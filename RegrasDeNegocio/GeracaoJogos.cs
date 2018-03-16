using System;
using System.Collections.Generic;
using System.Linq;
using MegaSena.Model;

namespace MegaSena.RegrasDeNegocio
{
    public class GeracaoJogos
    {
        JogoDomain Jogo = new JogoDomain();

        public List<String> GeraJogos(JogoDomain Jogo)
        {
            int totalNumeros=0, Add=0, Numero, JogoIgual=0;
            List<int> NumerosTotal = new List<int>();
            Jogo.Jogos = new List<string>();
            Random random = new Random();

            //Total de numeros
            totalNumeros = Jogo.QuantidadeNumeros * Jogo.QuantidadeJogos;
        
            //Varre enquanto não formar todos os jogos
            while(Jogo.Jogos.Count<Jogo.QuantidadeJogos)
            {
                Numero = random.Next(1,60); //gera um numero aleatorio de 1 a 60

                if(!NumerosTotal.Contains(Numero)){ //se a lista total de numeros não conter o número gerado, o numero é adicionado na lista pra não repetir
                    NumerosTotal.Add(Numero);
                    Add=Add+1;
                }

                //se formar um jogo
                if(Add==Jogo.QuantidadeNumeros)
                {
                    String jogo = null;

                    Add=0;

                    foreach(var item in NumerosTotal){
                        jogo = jogo +" "+item;
                    }

                    Console.WriteLine(jogo);

                    // Se não for primeiro jogo, realiza a comparação com jogos anteriores
                    if(Jogo.Jogos.Count!=0)
                    {
                        for(int i=0;i<Jogo.Jogos.Count;i++)
                        {
                            Console.WriteLine("COMPARA: "+Jogo.Jogos[i]+"=="+jogo);
                            
                            if(Jogo.Jogos[i] == jogo)
                            {
                                JogoIgual++;
                                break;
                            }
                        }
                    }

                    if(JogoIgual==0)
                    {
                       Console.WriteLine("Jogo diferente");
                       Jogo.Jogos.Add(jogo);
                    }
                    
                    JogoIgual=0;
                    NumerosTotal.Clear();
                }
            }

            return Jogo.Jogos;
        }

        public List<String> GetJogos()
        {
            return Jogo.Jogos;
        }
    }
}