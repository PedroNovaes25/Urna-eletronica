import { Voto } from "./Voto";

export interface Candidato {

  legendaId : number
  nome : string
  nomeVice : string
  legenda : string
  votos : Voto[]

}
