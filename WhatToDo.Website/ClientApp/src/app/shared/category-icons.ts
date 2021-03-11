import { faUtensils, faRunning, faFilm, faMusic, faLandmark, faShoppingCart, faSpinner, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { CategoryIcon } from './models/category-icon.model';

interface Category_CategoryIcon {
  [category: string]: CategoryIcon;
}

export let icons: Category_CategoryIcon = {
  "Jedzenie": { name: "Jedzenie", bgColor: "#E4FF3C", icon: faUtensils},
  "Ciekawe Miejsca": { name: "Ciekawe Miejsca", bgColor: "#FF823C", icon: faLandmark },
  "Zakupy": { name: "Zakupy", bgColor: "#3CFFF3", icon: faShoppingCart },
  "Sport i Rekreacja": { name: "Sport i Rekreacja", bgColor: "#6EFF3C", icon: faRunning },
  "Kultura": { name: "Kultura", bgColor: "#FF3C3C", icon: faFilm },
  "Rozrywka": { name: "Rozrywka", bgColor: "#863CFF", icon: faMusic },
  "": { name: "", bgColor: "#", icon: faSpinner }
};
