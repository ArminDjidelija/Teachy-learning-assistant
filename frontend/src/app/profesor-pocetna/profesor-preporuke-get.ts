export interface Obavijesti {
  podaci: ObavijestiGetResp[]
  poruka: string
}

export interface ObavijestiGetResp {
  oblastId: number
  oblastName: string
  prosjecnaTacnost: number
  fileUrl: string
}
