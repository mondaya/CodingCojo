class CreateDojoSurveys < ActiveRecord::Migration
  def change
    create_table :dojo_surveys do |t|
      t.string :user_name
      t.string :dojo_location
      t.string :fav_lang
      t.string :comment

      t.timestamps null: false
    end
  end
end
