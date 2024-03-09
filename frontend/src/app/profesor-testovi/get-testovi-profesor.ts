export type Testovi = Test[]

export interface Test {
  id: number
  naziv: string
  aktivan: boolean
  trajanje: number
  ukupnoBodova: number
  isDeleted: boolean
  zavrsen: boolean
  aktivanDo: string
  razredId: number
  razred: any
  predmetId: number
  predmet: Predmet
  profesorId: number
  profesor: Profesor
}

export interface Predmet {
  id: number
  naziv: string
  isDeleted: boolean
}

export interface Profesor {
  id: number
  ime: string
  prezime: string
  email: string
  lozinka: string
}
