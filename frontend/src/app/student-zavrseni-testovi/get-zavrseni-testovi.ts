export type StudentTest = StudentTestResp[]

export interface StudentTestResp {
  id: number
  ukupnoBodova: number
  datumPocetka: string
  datumZavrsetka: string
  zavrsen: boolean
  testId: number
  test: Test
  studentId: number
  student: Student
}

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
  predmet: any
  profesorId: number
  profesor: any
}

export interface Student {
  id: number
  ime: string
  prezime: string
  email: string
  lozinka: string
  razredId: number
  razred: any
  logiran: boolean
}
