export type Root = PredmResponse[]

export interface PredmResponse {
  predmet: Predmet
  uspjesnost: number
}

export interface Predmet {
  id: number
  naziv: string
  isDeleted: boolean
}
