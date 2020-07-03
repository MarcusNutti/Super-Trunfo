using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Projeto em grupo desenvolvido para a disciplina Algoritmos I,
 * do curso de Engenharia de Computação, na Faculdade de Tecnologia Termomecanica,
 * durante o 1º semestre de 2020.
 * 
 * Made by:
 * Alexsander Vilaça Rodrigues
 * Frederico Alves de Oliveira Silva
 * João Victor Maieru Teixeira
 * Kauan Moreira Bortoloto
 * Marcus Augusto Casé Nutti
 */


namespace Super_Trunfo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            string[] nomeCarta = { "Cessna Citation X ", "Swearingen SJ30", "IAI 1124 Westwing", "Beech Beechjet 400", "Canadair Global Express", "Gulfstream G 1159 - V", "Dassault Falcon 2000", "Yakoklev YAK-40", "Bombardier CRJ 700", "British Aerospace 146 - 200", "Bombardier CRJ 900", "Fairchild 329 Jet", "Boeing 757 - 300", "Airbus A319 - 100", "Yakolev YAK - 42", "Airbus A330-300", "Airbus A340-600", "Boieng 747-400", "Concorde", "Airbus A3XX-200", "DC-8-73F", "Airbus A310 200F", "Boeing 757-200PF", "Boeing 767-300F (ER)", "Airbus A300-600AT", "Ilyushin IL-76MF", "Boeing 747-100", "Antonov An-225", "Dassault Rafale", "Sukhoi S-37", "AMX International", "Saab JA39 Gripen", "L. Martin F-35 Lightning II", "F-22 Raptor", "Sukhoi Su-47 Berkut", "Sukhoi Su-57" };
            double[] pesoMaxDaCarta = { 16.193, 5.5801, 10.375, 7.309, 41.275, 40.370, 16.250, 16.000, 32.885, 42.185, 36.00, 15.2, 122.472, 64, 56.5, 230, 365, 396.900, 185.065, 583, 161, 142, 115.650, 186.850, 150, 210, 340.2, 600, 22.5, 17.7, 13, 13, 5.895, 12.851, 8.625, 11.270 }; // Em toneladas
            double[] velocidadeDaCarta = { 945, 825, 858, 850, 880, 830, 878, 550, 785, 730, 790, 720, 800, 803, 750, 846, 857, 920, 2170, 850, 880, 840, 860, 860, 780, 780, 920, 820, 2350, 2350, 849, 1700, 1837, 2410, 1717, 2600 }; // Em km/h
            double[] altitudeDeVooCarta = { 13.6, 13.100, 12.5, 11.8, 15.5, 15.5, 15.5, 10.000, 10.600, 9.600, 10.6, 7, 11.2, 11.820, 9.050, 11.82, 11.82, 10.6, 15.550, 11.82, 11.6, 11.2, 11.6, 10.6, 10, 13.1, 10.6, 10, 16.775, 17.900, 12.9, 18, 17.600, 20, 18, 19.5 }; // Em km
            double[] comprimentoDaCarta = { 22.01, 12.09, 15.93, 14.8, 30.2, 29.40, 20.23, 20.36, 32.41, 28.55, 36.27, 21.28, 54.50, 33.84, 36.38, 63.7, 63, 45, 70.70, 62.17, 78.9, 57.1, 46.66, 47.3, 55, 56.16, 53.19, 70.70, 84, 15.27, 21.9, 13.23, 14.1, 15.4, 18.9, 22.6, 19.8 }; // Em m
            double[] alturaDaCarta = { 5.76, 3.94, 4.81, 4.5, 7.5, 7.7, 6.98, 6.50, 7.32, 8.61, 7.29, 7.2, 13.6, 11.76, 9.83, 16.84, 17.8, 19.3, 12.19, 24.1, 13.1, 15.81, 13.6, 15.9, 17.25, 14.45, 19.3, 18.1, 5.34, 6.4, 3.75, 4.7, 4.6, 5.1, 6.3, 4.74 }; // em m

            double mediaPesoMax;
            double mediaVelocidade;
            double mediaAltitude;
            double mediaComprimento;
            double mediaAltura;


            int[] cartasTiradas = new int[nomeCarta.Length];

            int maoJogador;
            int maoComputador;

            int contadorDeJogadasUniversal = 0;

            int pontuacaoDoJogador = 0;
            int pontuacaoDoComputador = 0;

            int opcaoMenu, ordemDeJogada;

            int aspectoAvalido;

            string auxDeValidacao;

            bool validacaoAceita;

            do
            {
                // Recebe a opcao inserida pelo usuário
                opcaoMenu = ExibirMenu(0, "0");

                // Reset de variavel.
                for (int count = 0; count < cartasTiradas.Length; count++)
                {
                    cartasTiradas[count] = 0;
                }

                switch (opcaoMenu)
                {
                    // Caso 1, iniciar jogo
                    case 1:

                        pontuacaoDoJogador = 0;
                        pontuacaoDoComputador = 0;

                        contadorDeJogadasUniversal = 0;

                        Console.Clear();

                        ordemDeJogada = OrdemDeJogada();

                        do
                        {
                            aspectoAvalido = 0;

                            mediaPesoMax = CalculoMedia(cartasTiradas, pesoMaxDaCarta, contadorDeJogadasUniversal);
                            mediaVelocidade = CalculoMedia(cartasTiradas, velocidadeDaCarta, contadorDeJogadasUniversal);
                            mediaAltitude = CalculoMedia(cartasTiradas, altitudeDeVooCarta, contadorDeJogadasUniversal);
                            mediaComprimento = CalculoMedia(cartasTiradas, comprimentoDaCarta, contadorDeJogadasUniversal);
                            mediaAltura = CalculoMedia(cartasTiradas, alturaDaCarta, contadorDeJogadasUniversal);


                            Console.Clear();

                            maoJogador = SacarCarta(cartasTiradas, nomeCarta.Length, contadorDeJogadasUniversal);
                            cartasTiradas[contadorDeJogadasUniversal] = maoJogador;
                            contadorDeJogadasUniversal++;

                            maoComputador = SacarCarta(cartasTiradas, nomeCarta.Length, contadorDeJogadasUniversal);
                            cartasTiradas[contadorDeJogadasUniversal] = maoComputador;
                            contadorDeJogadasUniversal++;

                            Console.WriteLine("Sua Carta é: \n");

                            MostrarCartar(maoJogador, nomeCarta, pesoMaxDaCarta, velocidadeDaCarta, altitudeDeVooCarta, comprimentoDaCarta, alturaDaCarta, 1);

                            // Bloco do jogador
                            if (ordemDeJogada % 2 == 1)
                            {
                                Console.WriteLine("\nQual aspecto você deseja comparar?");
                                Console.WriteLine("\n1. Peso Máximo.");
                                Console.WriteLine("2. Velocidade.");
                                Console.WriteLine("3. Altitude de Vôo.");
                                Console.WriteLine("4. Comprimento.");
                                Console.WriteLine("5. Altura.\n");

                                do
                                {
                                    validacaoAceita = false;

                                    auxDeValidacao = Console.ReadLine();
                                    if (int.TryParse(auxDeValidacao, out aspectoAvalido))
                                    {
                                        if (aspectoAvalido > 5 || aspectoAvalido < 1)
                                        {
                                            Console.WriteLine("Digite um número entre 1 e 5");
                                        }
                                        else
                                        {
                                            validacaoAceita = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Digite um número");
                                    }
                                } while (validacaoAceita == false);
                            }
                            // Bloco do Computador

                            // Dentro desse if else, o computador compara a sua carta com a média ANTERIOR ao saque
                            else
                            {
                                if (pesoMaxDaCarta[maoComputador] == 600)
                                {
                                    aspectoAvalido = 1;
                                }
                                else if (velocidadeDaCarta[maoComputador] == 2600)
                                {
                                    aspectoAvalido = 2;
                                }
                                else if (altitudeDeVooCarta[maoComputador] == 20)
                                {
                                    aspectoAvalido = 3;
                                }
                                else if (comprimentoDaCarta[maoComputador] == 84)
                                {
                                    aspectoAvalido = 4;
                                }
                                else if (alturaDaCarta[maoComputador] == 24.1)
                                {
                                    aspectoAvalido = 5;
                                }
                                else
                                {
                                    for (int count = 300; count > 70; count--)
                                    {
                                        if (pesoMaxDaCarta[maoComputador] >= ((mediaPesoMax * count) / 100))
                                        {
                                            aspectoAvalido = 1;
                                            break;
                                        }
                                        else if (velocidadeDaCarta[maoComputador] >= ((mediaVelocidade * count) / 100))
                                        {
                                            aspectoAvalido = 2;
                                            break;
                                        }
                                        else if (altitudeDeVooCarta[maoComputador] >= ((mediaAltitude * count) / 100))
                                        {
                                            aspectoAvalido = 3;
                                            break;
                                        }

                                        else if (comprimentoDaCarta[maoComputador] >= ((mediaComprimento * count) / 100))
                                        {
                                            aspectoAvalido = 4;
                                            break;
                                        }
                                        else if (alturaDaCarta[maoComputador] >= ((mediaAltura * count) / 100))
                                        {
                                            aspectoAvalido = 5;
                                            break;
                                        }
                                        else
                                        {
                                            aspectoAvalido = rnd.Next(5) + 1;
                                        }
                                    }
                                }


                                /*
                                else
                                {
                                    if (pesoMaxDaCarta[maoComputador] >= mediaPesoMax * 1.9)
                                        aspectoAvalido = 1;
                                    else if (velocidadeDaCarta[maoComputador] >= mediaVelocidade * 1.1)
                                        aspectoAvalido = 2;
                                    else if (altitudeDeVooCarta[maoComputador] >= mediaAltitude * 1.1)
                                        aspectoAvalido = 3;
                                    else if (comprimentoDaCarta[maoComputador] >= mediaComprimento * 1.1)
                                        aspectoAvalido = 4;
                                    else if (alturaDaCarta[maoComputador] >= mediaAltura * 1.1)
                                        aspectoAvalido = 5;
                                    else
                                    {
                                        if (pesoMaxDaCarta[maoComputador] >= mediaPesoMax * 1.0)
                                            aspectoAvalido = 1;
                                        else if (velocidadeDaCarta[maoComputador] >= mediaVelocidade * 1.0)
                                            aspectoAvalido = 2;
                                        else if (altitudeDeVooCarta[maoComputador] >= mediaAltitude * 1.0)
                                            aspectoAvalido = 3;
                                        else if (comprimentoDaCarta[maoComputador] >= mediaComprimento * 1.0)
                                            aspectoAvalido = 4;
                                        else if (alturaDaCarta[maoComputador] >= mediaAltura * 1.0)
                                            aspectoAvalido = 5;
                                        else
                                        {
                                            if (pesoMaxDaCarta[maoComputador] >= mediaPesoMax * 0.9)
                                                aspectoAvalido = 1;
                                            else if (velocidadeDaCarta[maoComputador] >= mediaVelocidade * 0.9)
                                                aspectoAvalido = 2;
                                            else if (altitudeDeVooCarta[maoComputador] >= mediaAltitude * 0.9)
                                                aspectoAvalido = 3;
                                            else if (comprimentoDaCarta[maoComputador] >= mediaComprimento * 0.9)
                                                aspectoAvalido = 4;
                                            else if (alturaDaCarta[maoComputador] >= mediaAltura * 0.9)
                                                aspectoAvalido = 5;
                                            else
                                            {
                                                if (pesoMaxDaCarta[maoComputador] >= mediaPesoMax * 0.8)
                                                    aspectoAvalido = 1;
                                                else if (velocidadeDaCarta[maoComputador] >= mediaVelocidade * 0.8)
                                                    aspectoAvalido = 2;
                                                else if (altitudeDeVooCarta[maoComputador] >= mediaAltitude * 0.8)
                                                    aspectoAvalido = 3;
                                                else if (comprimentoDaCarta[maoComputador] >= mediaComprimento * 0.8)
                                                    aspectoAvalido = 4;
                                                else if (alturaDaCarta[maoComputador] >= mediaAltura * 0.8)
                                                    aspectoAvalido = 5;
                                                else
                                                {
                                                    if (pesoMaxDaCarta[maoComputador] >= mediaPesoMax * 0.7)
                                                        aspectoAvalido = 1;
                                                    else if (velocidadeDaCarta[maoComputador] >= mediaVelocidade * 0.7)
                                                        aspectoAvalido = 2;
                                                    else if (altitudeDeVooCarta[maoComputador] >= mediaAltitude * 0.7)
                                                        aspectoAvalido = 3;
                                                    else if (comprimentoDaCarta[maoComputador] >= mediaComprimento * 0.7)
                                                        aspectoAvalido = 4;
                                                    else if (alturaDaCarta[maoComputador] >= mediaAltura * 0.7)
                                                        aspectoAvalido = 5;
                                                    else
                                                    {
                                                        aspectoAvalido = rnd.Next(5) + 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }*/
                            }

                            Console.WriteLine("");

                            for (int count = 0; count < 3; count++)
                            {
                                Console.Write(".");
                                System.Threading.Thread.Sleep(500);
                            }

                            Console.WriteLine("\n\nA carta do inimigo é: \n");
                            MostrarCartar(maoComputador, nomeCarta, pesoMaxDaCarta, velocidadeDaCarta, altitudeDeVooCarta, comprimentoDaCarta, alturaDaCarta, 0);

                            // Bloco de resultados
                            if (aspectoAvalido == 1)
                            {
                                Console.Write("\nO aspecto avaliado foi o Peso Máximo e");
                                for (int count = 0; count < 3; count++)
                                {
                                    Console.Write(".");
                                    System.Threading.Thread.Sleep(500);
                                }
                                if (pesoMaxDaCarta[maoJogador] > pesoMaxDaCarta[maoComputador])
                                {
                                    pontuacaoDoJogador++;
                                    Console.WriteLine("\nVocê fez um ponto !!!");
                                }
                                else if (pesoMaxDaCarta[maoComputador] > pesoMaxDaCarta[maoJogador])
                                {
                                    pontuacaoDoComputador++;
                                    Console.WriteLine("\nO computador fez um ponto.");
                                }
                                else
                                {
                                    Console.WriteLine("\nHouve um empate.");
                                }
                            }
                            else if (aspectoAvalido == 2)
                            {
                                Console.Write("\nO aspecto avaliado foi a Velocidade e");
                                for (int count = 0; count < 3; count++)
                                {
                                    Console.Write(".");
                                    System.Threading.Thread.Sleep(250);
                                }
                                if (velocidadeDaCarta[maoJogador] > velocidadeDaCarta[maoComputador])
                                {
                                    pontuacaoDoJogador++;
                                    Console.WriteLine("\nVocê fez um ponto !!!");
                                }
                                else if (velocidadeDaCarta[maoComputador] > velocidadeDaCarta[maoJogador])
                                {
                                    pontuacaoDoComputador++;
                                    Console.WriteLine("\nO computador fez um ponto.");
                                }
                                else
                                {
                                    Console.WriteLine("\nHouve um empate.");
                                }
                            }
                            else if (aspectoAvalido == 3)
                            {
                                Console.Write("\nO aspecto avaliado foi a Altitude de Vôo e");
                                for (int count = 0; count < 3; count++)
                                {
                                    Console.Write(".");
                                    System.Threading.Thread.Sleep(250);
                                }
                                if (altitudeDeVooCarta[maoJogador] > altitudeDeVooCarta[maoComputador])
                                {
                                    pontuacaoDoJogador++;
                                    Console.WriteLine("\nVocê fez um ponto !!!");
                                }
                                else if (altitudeDeVooCarta[maoComputador] > altitudeDeVooCarta[maoJogador])
                                {
                                    pontuacaoDoComputador++;
                                    Console.WriteLine("\nO computador fez um ponto.");
                                }
                                else
                                {
                                    Console.WriteLine("\nHouve um empate.");
                                }
                            }
                            else if (aspectoAvalido == 4)
                            {
                                Console.Write("\nO aspecto avaliado foi o Comprimento do avião e");
                                for (int count = 0; count < 3; count++)
                                {
                                    Console.Write(".");
                                    System.Threading.Thread.Sleep(250);
                                }
                                if (comprimentoDaCarta[maoJogador] > comprimentoDaCarta[maoComputador])
                                {
                                    pontuacaoDoJogador++;
                                    Console.WriteLine("\nVocê fez um ponto !!!");
                                }
                                else if (comprimentoDaCarta[maoComputador] > comprimentoDaCarta[maoJogador])
                                {
                                    pontuacaoDoComputador++;
                                    Console.WriteLine("\nO computador fez um ponto.");
                                }
                                else
                                {
                                    Console.WriteLine("\nHouve um empate.");
                                }
                            }
                            else if (aspectoAvalido == 5)
                            {
                                Console.Write("\nO aspecto avaliado foi a Altura do avião e");
                                for (int count = 0; count < 3; count++)
                                {
                                    Console.Write(".");
                                    System.Threading.Thread.Sleep(250);
                                }
                                if (alturaDaCarta[maoJogador] > alturaDaCarta[maoComputador])
                                {
                                    pontuacaoDoJogador++;
                                    Console.WriteLine("\nVocê fez um ponto !!!");
                                }
                                else if (alturaDaCarta[maoComputador] > alturaDaCarta[maoJogador])
                                {
                                    pontuacaoDoComputador++;
                                    Console.WriteLine("\nO computador fez um ponto.");
                                }
                                else
                                {
                                    Console.WriteLine("\nHouve um empate.");
                                }
                            }

                            ordemDeJogada++;

                            Console.WriteLine("\n\nO placar agora está: {0} para você e {1} para o computador.\n", pontuacaoDoJogador, pontuacaoDoComputador);

                            Console.WriteLine("Pressione qualquer tecla para continuar.");

                            Console.ReadKey();

                            if (contadorDeJogadasUniversal == nomeCarta.Length)
                            {
                                Console.Clear();
                                Console.WriteLine("A partida foi encerrada!!!");
                                Console.WriteLine("\nSua pontuação foi de: {0}", pontuacaoDoJogador);
                                Console.WriteLine("\nA pontuação do computador foi de: {0}", pontuacaoDoComputador);
                                if (pontuacaoDoJogador > pontuacaoDoComputador)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n\nVocê ganhou a partida.");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    System.Threading.Thread.Sleep(250);

                                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\nO computador ganhou a partida.");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    System.Threading.Thread.Sleep(250);

                                    Console.WriteLine("\nPressione qualquer tecla para continuar.");
                                    Console.ReadKey();
                                }
                            }

                        }
                        while (contadorDeJogadasUniversal < nomeCarta.Length);


                        break;

                    // Caso 2, exibe instrucoes
                    case 2:

                        // Limpa o console
                        Console.Clear();

                        // Define cor da letra pra vermelho
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Objetivo: \n");
                        // Volta a letra para a cor branca
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("* O objetivo do jogo é vencer mais rodadas que o seu oponente.\n" +
                            "* São 16 rodadas no total.\n" +
                            "* Ao término delas o competidor com mais rodadas vencidas é o vencedor.\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nAspectos: \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("* A cada rodada o jogador ou o computador escolherá um aspecto a ser avaliado.\n" +
                            "* A ordem de escolha a cada rodada é alternada." +
                            " Isto é, em uma rodada\n " +
                            " você escolhe primeiro, na outra o computador, e assim sucessivamente." +
                            "\n* Vence a rodada quem tiver o maior valor naquele aspecto.\n" +
                            "* Os aspectos disponíveis são Peso Máximo; Velocidade Máxima;\n" +
                            "  Altitude de Vôo; Comprimento; e Altura.");
                        Console.Write("\n\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();

                        for (int count = 0; count < nomeCarta.Length; count++)
                        {
                            MostrarCartar(count, nomeCarta, pesoMaxDaCarta, velocidadeDaCarta, altitudeDeVooCarta, comprimentoDaCarta, alturaDaCarta, 1);
                            Console.WriteLine("\n\n\n");
                        }

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");

                        Console.ReadKey();
                        break;


                    // Caso 4, sai do programa
                    case 4:
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
            } while (true);

        }

        static int ExibirMenu(int aux, string auxb)
        {
            // Logo 100/10
            Console.WriteLine("---------------------");
            Console.WriteLine("Super Trunfo de Avião");
            Console.WriteLine("---------------------");

            // Opcoes
            Console.Write("Selecione uma das opcões abaixo: \n");
            Console.Write("\n1. Jogar.");
            Console.Write("\n2. Instruções e regras do jogo.");
            Console.Write("\n3. Galeria de cartas.");
            Console.Write("\n4. Sair.\n\n");

            // Autenticacao de valor inserido
            do
            {
                auxb = Console.ReadLine();
                if (int.TryParse(auxb, out aux) == false)
                    Console.Write("\nDigite um número!!!\n");
                else if (aux <= 0 || aux > 4)
                    Console.Write("\nDigite uma opcão válida!!!\n");
            }
            while (int.TryParse(auxb, out aux) == false || aux <= 0 || aux > 4);

            // Retorno de váriavel para o método
            if (aux == 1)
                return 1;
            else if (aux == 2)
                return 2;
            else if (aux == 3)
                return 3;
            else if (aux == 4)
                return 4;
            else
                return 0;
        }

        static int OrdemDeJogada()
        {
            string auxSelecaoDeCores;
            int corDoJogador;

            // Numero aleatório
            Random rnd = new Random();

            // Opcoes
            Console.WriteLine("Você deseja jogar primeiro? ");
            Console.WriteLine("\n1. Sim.");
            Console.WriteLine("2. Não.");
            Console.WriteLine("3. Aleatório.");

            // Autenticacao da entrada
            do
            {
                Console.Write("\nDigite sua escolha: ");
                auxSelecaoDeCores = Console.ReadLine();
                if (int.TryParse(auxSelecaoDeCores, out corDoJogador) == false)
                    Console.Write("Digite um número!!!");
                else if (Convert.ToInt32(auxSelecaoDeCores) > 3 || Convert.ToInt32(auxSelecaoDeCores) < 1)
                    Console.Write("Digite um valor entre 1 e 3!!!");
                else if (Convert.ToInt32(auxSelecaoDeCores) == 3)
                    corDoJogador = rnd.Next(2) + 1;
                else
                    corDoJogador = Convert.ToInt32(auxSelecaoDeCores);
            }
            while (corDoJogador != 1 && corDoJogador != 2);

            // Informar o jogador da sua cor
            if (corDoJogador == 1)
                Console.Write("\nVocê jogará primeiro.");

            else
                Console.Write("\nVocê jogará após o computador.");

            // Contagem frufru
            Console.Write("\n\nIniciando partida");
            for (int count = 0; count < 4; count++)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
            }

            // Retorno dos valores
            if (corDoJogador == 1)
                return 1;
            else
                return 2;

        }

        static void MostrarCartar(int numeroDaCarta, string[] nomeCarta, double[] pesoMaxDaCarta, double[] velocidadeDaCarta, double[] altitudeDeVooCarta, double[] comprimentoDaCarta, double[] alturaDaCarta, int cor)
        {
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.Write("Nome: {0}", nomeCarta[numeroDaCarta]);

            for (int count = 0; nomeCarta[numeroDaCarta].Length + count < 30; count++)
            {
                Console.Write(" ");
            }

            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (pesoMaxDaCarta[numeroDaCarta] < 10)
            {
                Console.Write("Peso Máximo: {0:F3} toneladas        ", pesoMaxDaCarta[numeroDaCarta]);
            }
            else if (pesoMaxDaCarta[numeroDaCarta] > 10 && pesoMaxDaCarta[numeroDaCarta] < 100)
            {
                Console.Write("Peso Máximo: {0:F2} toneladas        ", pesoMaxDaCarta[numeroDaCarta]);
            }
            else
            {
                Console.Write("Peso Máximo: {0:F2} toneladas       ", pesoMaxDaCarta[numeroDaCarta]);
            }
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (velocidadeDaCarta[numeroDaCarta] > 1000)
            {
                Console.Write("Velocidade Máxima: {0:F1} km/h      ", velocidadeDaCarta[numeroDaCarta]);
            }
            else
            {
                Console.Write("Velocidade Máxima: {0:F2} km/h      ", velocidadeDaCarta[numeroDaCarta]);
            }
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (altitudeDeVooCarta[numeroDaCarta] < 10)
            {
                Console.Write("Altitude de Vôo: {0:F3} km           ", altitudeDeVooCarta[numeroDaCarta]);
            }
            else
            {
                Console.Write("Altitude de Vôo: {0:F2} km           ", altitudeDeVooCarta[numeroDaCarta]);
            }
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.Write("Comprimento: {0:F2} m                ", comprimentoDaCarta[numeroDaCarta]);
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (alturaDaCarta[numeroDaCarta] > 10)
            {
                Console.Write("Altura: {0:F1} m                      ", alturaDaCarta[numeroDaCarta]);
            }
            else
            {
                Console.Write("Altura: {0:F2} m                      ", alturaDaCarta[numeroDaCarta]);
            }
            if (cor == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("|");
                Console.WriteLine("\n_____________________________________");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        static int SacarCarta(int[] cartasTiradas, int numeroTotalDeCartasDoBaralho, int contadorDeJogadasUniversal)
        {
            int cartaSacada;

            bool cartaRepetida;

            Random rnd = new Random();

            do
            {
                cartaRepetida = false;

                cartaSacada = rnd.Next(numeroTotalDeCartasDoBaralho);

                for (int count = 0; count < contadorDeJogadasUniversal; count++)
                {
                    if (cartaSacada == cartasTiradas[count])
                    {
                        cartaRepetida = true;
                    }
                }
            }
            while (cartaRepetida);

            return cartaSacada;
        }

        static double CalculoMedia(int[] cartasTiradas, double[] parematroASerCalculado, int contadorDeJogadasUniversal)
        {
            double media = 0;
            double somatorio = 0;
            int numeroDeElementos = 0;

            for (int count = 0; count < parematroASerCalculado.Length; count++)
            {
                for (int countb = 0; countb < contadorDeJogadasUniversal; countb++)
                {
                    if (cartasTiradas[countb] != count)
                    {
                        somatorio += parematroASerCalculado[count];
                        numeroDeElementos++;
                    }
                }
                if (contadorDeJogadasUniversal == 0)
                {
                    somatorio += parematroASerCalculado[count];
                    numeroDeElementos++;
                }
            }

            media = somatorio / numeroDeElementos;

            return media;
        }
    }
}