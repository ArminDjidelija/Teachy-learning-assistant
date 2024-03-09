export type OblastResp = OblastResponse[]

export interface OblastResponse {
  predmet: Predmet
  oblast: Oblast
  fileUrl: string
}

export interface Predmet {
  id: number
  naziv: string
  isDeleted: boolean
}

export interface Oblast {
  id: number
  naziv: string
  predmetId: number
  predmet: Predmet2
  nazivFajla: any
}

export interface Predmet2 {
  id: number
  naziv: string
  isDeleted: boolean
}
