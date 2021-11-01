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

  async getById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log(res)
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('createKeep', res)
    AppState.keeps.unshift(res.data)
  }

  // async addView(editable) {
  //   const res = await api.put(`api/keeps/${editable.id}`, editable)
  //   logger.log(res)
  // }
}

export const keepsService = new KeepsService()