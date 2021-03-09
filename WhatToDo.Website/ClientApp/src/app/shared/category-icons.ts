import { faUtensils, faRunning, faFilm, faMusic, faLandmark, faShoppingCart, faSpinner, IconDefinition } from '@fortawesome/free-solid-svg-icons';

interface CategoryIcon {
  [category: string]: IconDefinition;
}

export let icons: CategoryIcon = {
  "Jedzenie": faUtensils,
  "Ciekawe Miejsca": faLandmark,
  "Zakupy": faShoppingCart,
  "Sport i Rekreacja": faRunning,
  "Kultura": faFilm,
  "Rozrywka": faMusic,
  "" : faSpinner
};
