import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{

  async getKeeps() {
    AppState.keeps = []
    const res = await api.get('api/keeps')
    logger.log('getKeeps' ,res.data)
    AppState.keeps = res.data
  }

  async addView(editable) {
    const res = await api.put(`api/keeps/${editable.id}`, editable)
    logger.log(res)
  }
}

export const keepsService = new KeepsService()