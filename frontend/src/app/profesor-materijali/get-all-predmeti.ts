export type PredmetiGetAll = PredmetiGetAllResponse[]

export interface PredmetiGetAllResponse {
  id: number
  naziv: string
  isDeleted: boolean
}
