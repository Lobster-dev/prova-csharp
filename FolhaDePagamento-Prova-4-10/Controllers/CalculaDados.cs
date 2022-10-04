namespace API.Controller
{
    public class CalculaDados
    {
        public double calcularSalarioBruto(double ValorHora, int QuantidadeDeHoras) => ValorHora * QuantidadeDeHoras;
        public double calculaImporstoDeRenda(double SalarioBruto)
        {
            double aliquota = 0.0;
            if (SalarioBruto <= 1903.98)
            {
                return SalarioBruto;
            }

            if (SalarioBruto <= 2826.65)
            {
                aliquota = 0.075;
            }
            else
            {
                if (SalarioBruto <= 3751.65)
                {
                    aliquota = 0.15;
                }
                else
                {
                    if (SalarioBruto <= 4664.68)
                    {
                        aliquota = 0.225;
                    }
                    else
                    {
                        if (SalarioBruto > 4664.68)
                        {
                            aliquota = 0.275;
                        }
                    }
                }
            }
            return SalarioBruto * aliquota;
            
            // switch (SalarioBruto)
            // {
            //     case > 1903.99 and < 2826.65:
            //         aliquota = 7.5;
            //         break;
            //     case < 3751.65:
            //         aliquota = 15;
            //         break;
            //     case < 4664.68:
            //         aliquota = 22.5;
            //         break;
            //     case > 4664.68:
            //         aliquota = 27.5;
            //         break;
            // }

        }

        public double calculaInss(double SalarioBruto)
        {
            double desconto = 0.08;

            if (SalarioBruto <= 1693.72)
            {
                return SalarioBruto * desconto;
            }
            else
            {
                if (SalarioBruto <= 2822.90)
                {
                    desconto = 0.09;
                }else
                {
                    if (SalarioBruto <= 5645.8)
                    {
                        desconto = 0.11;
                    }else
                    {
                        if (SalarioBruto > 5645.81)
                        {
                            return SalarioBruto - 621.03;
                        }
                    }
                }
            }
            
            return SalarioBruto * desconto;
        }

        public double calculaSalarioLiquido(
                double salarioBruto,
                double valorIR,
                double valorInss
            ) => salarioBruto - valorIR - valorIR;

        public double CalculaValorFGTS(
                double SalarioBruto
            ) => SalarioBruto * 0.08;
    }
}