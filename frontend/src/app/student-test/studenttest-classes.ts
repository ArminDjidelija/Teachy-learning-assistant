export interface ListaKorisnikaResponse {
  listaKorisnika: ListaKorisnika[]
}

export interface ListaKorisnika {
  studentID: number
  testID: number
  odgovorID: number |null
  esejsko: string | null
}
