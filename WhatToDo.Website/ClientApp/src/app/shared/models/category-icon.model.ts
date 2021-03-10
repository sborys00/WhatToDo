import { IconDefinition } from '@fortawesome/free-solid-svg-icons';

export class CategoryIcon {
  name: string;
  bgColor: string;
  icon: IconDefinition;

  constructor(name: string, color: string, icon: IconDefinition) {
    this.name = name;
    this.bgColor = color;
    this.icon = icon;
  }

}
