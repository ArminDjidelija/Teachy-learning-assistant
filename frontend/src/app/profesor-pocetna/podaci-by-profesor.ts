export type GetPodaciByProff = GetPodaciByProffRespo[]

export interface GetPodaciByProffRespo {
  testId: TestId
  brojStudenata: number
  prosjecnaProlaznost: number
}

export interface TestId {
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
  predmet: any
  profesorId: number
  profesor: any
}
