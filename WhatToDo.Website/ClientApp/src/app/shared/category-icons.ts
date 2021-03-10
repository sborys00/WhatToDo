import { faUtensils, faRunning, faFilm, faMusic, faLandmark, faShoppingCart, faSpinner, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { CategoryIcon } from './models/category-icon.model';

interface Category_CategoryIcon {
  [category: string]: CategoryIcon;
}

export let icons: Category_CategoryIcon = {
  "Jedzenie": { name: "Jedzenie", bgColor: "#ffff00", icon: faUtensils},
  "Ciekawe Miejsca": { name: "Ciekawe Miejsca", bgColor: "#ff8000", icon: faLandmark },
  "Zakupy": { name: "Zakupy", bgColor: "#ff0000", icon: faShoppingCart },
  "Sport i Rekreacja": { name: "Sport i Rekreacja", bgColor: "#00ff00", icon: faRunning },
  "Kultura": { name: "Kultura", bgColor: "#00ffff", icon: faFilm },
  "Rozrywka": { name: "Rozrywka", bgColor: "#ff00d9", icon: faMusic },
  "": { name: "", bgColor: "#", icon: faSpinner }
};
